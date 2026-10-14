using System;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Displays local events and announcements, lets the user search by
    /// category and/or date, and shows personalised recommendations based
    /// on what the user has searched for during this session.
    /// </summary>
    public partial class LocalEventsForm : Form
    {
        public LocalEventsForm()
        {
            InitializeComponent();
            lvEvents.ShowItemToolTips = true; // hover an event to read its description
            LoadCategoryFilter();
            DisplayEvents(EventRepository.AllEventsChronological().ToList());
            RefreshRecommendations();
        }

        private void LoadCategoryFilter()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");

            // Categories come from the HashSet<string>, so the list is
            // guaranteed to contain no duplicates; sort alphabetically for display.
            foreach (var category in EventRepository.Categories.OrderBy(c => c))
            {
                cmbCategoryFilter.Items.Add(category);
            }

            cmbCategoryFilter.SelectedIndex = 0;

            if (EventRepository.EventDates.Count > 0)
            {
                dtpDateFilter.MinDate = EventRepository.EventDates.Min();
                dtpDateFilter.MaxDate = EventRepository.EventDates.Max();
                dtpDateFilter.Value = EventRepository.EventDates.Min();
            }
        }

        private void DisplayEvents(System.Collections.Generic.List<LocalEvent> events)
        {
            lvEvents.Items.Clear();

            foreach (var ev in events)
            {
                var item = new ListViewItem(ev.Title);
                item.SubItems.Add(ev.Category);
                item.SubItems.Add(ev.Date.ToString("dd MMM yyyy"));
                item.SubItems.Add(ev.Location);
                item.Tag = ev;
                item.ToolTipText = ev.Description;
                lvEvents.Items.Add(item);
            }

            if (events.Count == 0)
            {
                var empty = new ListViewItem("No events found matching your search.");
                empty.ForeColor = System.Drawing.Color.Gray;
                lvEvents.Items.Add(empty);
            }
        }

        private void chkFilterByDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateFilter.Enabled = chkFilterByDate.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategoryFilter.SelectedItem?.ToString();
            DateTime? selectedDate = chkFilterByDate.Checked ? (DateTime?)dtpDateFilter.Value : null;

            var results = EventRepository.Search(selectedCategory, selectedDate);
            DisplayEvents(results);

            // Feed the recommendation engine with this search.
            EventRepository.RecordSearch(selectedCategory);
            RefreshRecommendations();
            RefreshRecentSearches();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            cmbCategoryFilter.SelectedIndex = 0;
            chkFilterByDate.Checked = false;
            DisplayEvents(EventRepository.AllEventsChronological().ToList());
        }

        /// <summary>
        /// Refreshes the recommendation panel using EventRepository's
        /// search-pattern analysis (the "Additional Recommendation Feature").
        /// </summary>
        private void RefreshRecommendations()
        {
            lstRecommendations.Items.Clear();

            var recommendations = EventRepository.GetRecommendations(5);
            string topCategory = EventRepository.MostSearchedCategory();

            lblRecommended.Text = topCategory == null
                ? "Recommended for you (soonest upcoming events):"
                : "Recommended for you (based on your interest in \"" + topCategory + "\"):";

            if (recommendations.Count == 0)
            {
                lstRecommendations.Items.Add("No recommendations available yet - try searching for a category.");
                return;
            }

            foreach (var ev in recommendations)
            {
                lstRecommendations.Items.Add(ev.Title + "  |  " + ev.Category + "  |  " +
                    ev.Date.ToString("dd MMM yyyy") + "  |  " + ev.Location);
            }
        }

        private void RefreshRecentSearches()
        {
            var recent = EventRepository.GetRecentSearches(3);
            lblRecentSearches.Text = recent.Count == 0
                ? "Recent searches: none yet"
                : "Recent searches (newest first): " + string.Join("  >  ", recent);
        }

        private void btnNextAnnouncement_Click(object sender, EventArgs e)
        {
            LocalEvent next = EventRepository.NextAnnouncement();
            if (next == null)
            {
                MessageBox.Show("There are no announcements at the moment.", "Announcements",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show(
                next.Title + "\n\n" + next.Description + "\n\nDate: " + next.Date.ToString("dd MMM yyyy") +
                "\nLocation: " + next.Location,
                "Announcement - " + next.Category,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lvEvents_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // Reserved for future detail-view functionality (e.g. showing the
            // full description of the selected event). Left intentionally
            // minimal for Part 2's scope.
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
