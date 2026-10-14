using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Central, in-memory store for local events and announcements. Several
    /// different data structures are deliberately used here, each because it
    /// is the right tool for a specific access pattern required by the
    /// specification, rather than using one structure for everything:
    ///
    /// - SortedDictionary&lt;DateTime, List&lt;LocalEvent&gt;&gt;: keeps every event
    ///   organised chronologically at all times with O(log n) insertion, which
    ///   is what "optimise event organisation" calls for.
    /// - Dictionary&lt;string, List&lt;LocalEvent&gt;&gt; (a hash table): gives O(1)
    ///   average lookup of every event in a given category, used by the
    ///   category search.
    /// - HashSet&lt;string&gt; / HashSet&lt;DateTime&gt;: track the unique categories and
    ///   unique dates in use, so the search UI's dropdowns never contain
    ///   duplicates and membership checks are O(1).
    /// - Queue&lt;LocalEvent&gt;: processes newly-added events in the order they
    ///   were published (FIFO), modelling how a municipality would announce
    ///   events to citizens in publication order.
    /// - SimplePriorityQueue&lt;LocalEvent, DateTime&gt;: always surfaces the
    ///   soonest-occurring event first for the "Happening Soon" panel,
    ///   regardless of the order events were added in.
    /// - Stack&lt;string&gt;: records the user's most recent category searches
    ///   (LIFO), which the recommendation feature uses to weigh the most
    ///   recent interest more heavily.
    /// </summary>
    public static class EventRepository
    {
        private static readonly SortedDictionary<DateTime, List<LocalEvent>> _eventsByDate =
            new SortedDictionary<DateTime, List<LocalEvent>>();

        private static readonly Dictionary<string, List<LocalEvent>> _eventsByCategory =
            new Dictionary<string, List<LocalEvent>>(StringComparer.OrdinalIgnoreCase);

        private static readonly HashSet<string> _categories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static readonly HashSet<DateTime> _eventDates = new HashSet<DateTime>();

        private static readonly Queue<LocalEvent> _publicationQueue = new Queue<LocalEvent>();
        private static readonly SimplePriorityQueue<LocalEvent, DateTime> _upcomingPriorityQueue =
            new SimplePriorityQueue<LocalEvent, DateTime>();

        // Search-pattern tracking for the recommendation feature.
        private static readonly Stack<string> _recentCategorySearches = new Stack<string>();
        private static readonly Dictionary<string, int> _categorySearchFrequency =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private static int _nextId = 1;

        static EventRepository()
        {
            SeedSampleEvents();
        }

        public static IReadOnlyCollection<string> Categories => _categories;

        public static IReadOnlyCollection<DateTime> EventDates => _eventDates;

        public static IEnumerable<LocalEvent> AllEventsChronological()
        {
            // SortedDictionary keeps keys in order, so a simple flatten preserves chronology.
            foreach (var dateGroup in _eventsByDate)
            {
                foreach (var ev in dateGroup.Value)
                {
                    yield return ev;
                }
            }
        }

        public static LocalEvent AddEvent(string title, string category, DateTime date, string location, string description)
        {
            var ev = new LocalEvent
            {
                Id = _nextId++,
                Title = title,
                Category = category,
                Date = date.Date,
                Location = location,
                Description = description
            };

            if (!_eventsByDate.TryGetValue(ev.Date, out var dateList))
            {
                dateList = new List<LocalEvent>();
                _eventsByDate[ev.Date] = dateList;
            }
            dateList.Add(ev);

            if (!_eventsByCategory.TryGetValue(ev.Category, out var catList))
            {
                catList = new List<LocalEvent>();
                _eventsByCategory[ev.Category] = catList;
            }
            catList.Add(ev);

            _categories.Add(ev.Category);
            _eventDates.Add(ev.Date);
            _publicationQueue.Enqueue(ev);
            _upcomingPriorityQueue.Enqueue(ev, ev.Date);

            return ev;
        }

        /// <summary>
        /// Searches events using the category hash table and/or the sorted
        /// date dictionary. Either filter may be left null/empty to match all.
        /// </summary>
        public static List<LocalEvent> Search(string category, DateTime? date)
        {
            IEnumerable<LocalEvent> results = AllEventsChronological();

            if (!string.IsNullOrWhiteSpace(category) && category != "All Categories")
            {
                results = _eventsByCategory.TryGetValue(category, out var catList)
                    ? catList
                    : new List<LocalEvent>();
            }

            if (date.HasValue)
            {
                results = results.Where(e => e.Date.Date == date.Value.Date);
            }

            return results.OrderBy(e => e.Date).ToList();
        }

        /// <summary>
        /// Returns the n soonest upcoming events using the priority queue,
        /// without mutating the underlying queue.
        /// </summary>
        public static List<LocalEvent> GetUpcoming(int count)
        {
            return _upcomingPriorityQueue.PeekTopN(count);
        }

        /// <summary>
        /// Records that the user searched for a given category, which feeds
        /// the recommendation feature below.
        /// </summary>
        public static void RecordSearch(string category)
        {
            if (string.IsNullOrWhiteSpace(category) || category == "All Categories") return;

            _recentCategorySearches.Push(category);

            if (_categorySearchFrequency.ContainsKey(category))
                _categorySearchFrequency[category]++;
            else
                _categorySearchFrequency[category] = 1;
        }

        /// <summary>
        /// User engagement / recommendation feature: analyses the user's
        /// search history (most frequent category, falling back to the most
        /// recent one on a tie) and suggests other upcoming events in that
        /// category that the search itself may not have returned.
        /// </summary>
        public static List<LocalEvent> GetRecommendations(int maxResults)
        {
            if (_categorySearchFrequency.Count == 0)
            {
                // No search history yet - recommend soon-to-happen events generally.
                return GetUpcoming(maxResults);
            }

            string topCategory = _categorySearchFrequency
                .OrderByDescending(kvp => kvp.Value)
                .ThenByDescending(kvp => _recentCategorySearches.Contains(kvp.Key) ? 1 : 0)
                .First().Key;

            var recommendations = _eventsByCategory.TryGetValue(topCategory, out var catList)
                ? catList.Where(e => e.Date >= DateTime.Today).OrderBy(e => e.Date).Take(maxResults).ToList()
                : new List<LocalEvent>();

            if (recommendations.Count < maxResults)
            {
                // Top up with other soon-upcoming events the user hasn't already seen recommended.
                var extra = GetUpcoming(maxResults).Where(e => !recommendations.Contains(e));
                recommendations.AddRange(extra.Take(maxResults - recommendations.Count));
            }

            return recommendations;
        }

        /// <summary>
        /// Returns the user's most recent category searches, newest first.
        /// A Stack enumerates in LIFO order, so the top of the stack (the
        /// latest search) comes out first - exactly what a "recent searches"
        /// list needs.
        /// </summary>
        public static List<string> GetRecentSearches(int count)
        {
            return _recentCategorySearches.Take(count).ToList();
        }

        /// <summary>
        /// Announcement carousel: takes the next announcement from the front
        /// of the publication queue (FIFO) and puts it back at the end, so
        /// announcements cycle in the order they were published.
        /// </summary>
        public static LocalEvent NextAnnouncement()
        {
            if (_publicationQueue.Count == 0) return null;

            LocalEvent next = _publicationQueue.Dequeue();
            _publicationQueue.Enqueue(next);
            return next;
        }

        public static string MostSearchedCategory()
        {
            return _categorySearchFrequency.Count == 0
                ? null
                : _categorySearchFrequency.OrderByDescending(kvp => kvp.Value).First().Key;
        }

        private static void SeedSampleEvents()
        {
            // Sample municipal events so the feature can be demonstrated without
            // requiring the Report Issues workflow to be used first.
            AddEvent("Ward 12 Community Clean-Up", "Sanitation", DateTime.Today.AddDays(3), "Khayelitsha Community Hall", "Join residents in a neighbourhood clean-up drive. Gloves and bags provided.");
            AddEvent("Water Supply Maintenance Notice", "Water and Sewerage", DateTime.Today.AddDays(1), "Mitchells Plain", "Scheduled maintenance will interrupt water supply from 08:00 to 16:00.");
            AddEvent("Load Shedding Schedule Briefing", "Electricity", DateTime.Today.AddDays(5), "Civic Centre, Cape Town", "Public briefing on the updated load shedding schedule for the quarter.");
            AddEvent("Pothole Repair Drive - Main Road", "Roads and Potholes", DateTime.Today.AddDays(7), "Main Road, Observatory", "Road maintenance crews will be repairing potholes along Main Road.");
            AddEvent("Neighbourhood Watch Meeting", "Public Safety", DateTime.Today.AddDays(2), "Rondebosch Community Centre", "Monthly neighbourhood watch meeting - all residents welcome.");
            AddEvent("Spring Park Clean-Up & Planting Day", "Parks and Recreation", DateTime.Today.AddDays(10), "Green Point Park", "Help plant indigenous trees and clean up the park for spring.");
            AddEvent("Refuse Collection Schedule Change", "Refuse Collection", DateTime.Today.AddDays(4), "Area-wide", "Refuse collection will move from Tuesdays to Wednesdays starting next month.");
            AddEvent("Youth Soccer Tournament", "Parks and Recreation", DateTime.Today.AddDays(14), "Athlone Stadium", "Annual inter-ward youth soccer tournament, all welcome to attend.");
            AddEvent("Electricity Bill Query Workshop", "Electricity", DateTime.Today.AddDays(6), "Bellville Civic Centre", "Municipal staff will assist residents with electricity billing queries.");
            AddEvent("Sanitation Awareness Campaign", "Sanitation", DateTime.Today.AddDays(12), "Various Wards", "Public awareness campaign on responsible waste disposal.");
        }
    }
}
