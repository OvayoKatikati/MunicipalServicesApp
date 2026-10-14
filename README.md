# Municipal Services Application — Part 2: Local Events and Announcements

**Student number:** ST10155583
**Module:** Programming 3B (PROG7312) / Advanced Application Development (AAPD7112/w)

A C# Windows Forms (.NET Framework 4.7.2) desktop application for South African
municipal services. Part 1 delivered **Report Issues**. Part 2 adds **Local Events
and Announcements**. **Service Request Status** stays disabled until the PoE task. A **login and
registration screen** was added as an extra feature beyond the brief.

## Requirements

- Windows 10/11
- Visual Studio 2019 or 2022 with the **.NET desktop development** workload
  (includes the .NET Framework 4.7.2 targeting pack)
- No NuGet packages or external libraries are needed.

## How to Compile and Run

1. Unzip the project folder and open **MunicipalServicesApp.sln** in Visual Studio.
2. Choose **Build > Rebuild Solution** (it should finish with 0 errors).
3. Press **F5** (or **Start**) to run. Alternatively run
   `bin\Debug\MunicipalServicesApp.exe` after building.

## How to Use the Application

### Login (shown on startup - extra feature)
1. Log in with the demo account: **Username** `resident`, **Password** `Password1`.
2. Or click **New resident? Create an account**, enter a full name, a username (at
   least 3 characters) and a password (at least 6 characters), then log in with it.
3. Wrong details, empty fields and duplicate usernames show a clear message on screen.
4. Tick **Show password** to see what you are typing.
5. Passwords are never stored in plain text: each account gets a random salt and the
   password is hashed with PBKDF2 before it is kept in memory.
6. Closing the login window exits the application.

### Main Menu (shown after login)
The menu greets you by name. Click **Log Out** (bottom right), confirm, and you are
returned to the login screen. Three options are shown: **Report Issues**, **Local Events and Announcements**, and
**Service Request Status** (disabled — "Coming Soon").

### Report Issues (Part 1)
1. Enter the **Location**, choose a **Category**, and type a **Description**.
2. Optionally click **Attach Image / Document** to attach files (file dialog).
3. The progress bar and message at the bottom update live as you complete the form
   (the user engagement feature).
4. Click **Submit**. A message box confirms the report and gives a reference number.
   Missing required fields produce a warning instead.
5. Click **View Reported Issues** to see every issue reported this session.
6. Click **Back to Main Menu** to return.

### Local Events and Announcements (Part 2)
1. The page opens with ten sample events, listed in date order (soonest first).
   Hover over an event to read its description.
2. **Search:** pick a **Category** (or "All Categories"). Tick **Use** next to **Date**
   and choose a date to filter by that day too. Click **Search**. Click **Show All**
   to reset.
3. **Recommended for you:** the panel under the table updates after every search. It
   works out which category you search for most and recommends upcoming events in it,
   including ones your last search did not show. Before you have searched, it shows
   the soonest upcoming events instead.
4. **Recent searches** (bottom left) lists your last three category searches, newest
   first.
5. **Next Announcement** shows the next announcement in the order they were published
   and cycles back to the first after the last.
6. Click **Back to Main Menu** to return.

## Project Structure

| File | Purpose |
|---|---|
| `Program.cs` | Entry point; shows the login screen, then the main menu, and loops back to login on Log Out. |
| `LoginForm.cs` / `.Designer.cs` | Extra feature: login and registration screen. |
| `User.cs` / `UserRepository.cs` | Extra feature: account model and in-memory salted-hash credential store. |
| `MainMenuForm.cs` / `.Designer.cs` | Main menu (3 options), welcome message and Log Out. |
| `ReportIssuesForm.cs` / `.Designer.cs` | Part 1: Report Issues form, validation, engagement bar. |
| `ReportedIssuesForm.cs` | Read-only list of reported issues. |
| `Issue.cs` / `IssueRepository.cs` | Part 1: issue model and `List<Issue>` store. |
| `LocalEventsForm.cs` / `.Designer.cs` | Part 2: events list, search, recommendations. |
| `LocalEvent.cs` | Part 2: event model. |
| `EventRepository.cs` | Part 2: event storage, search and recommendation logic. |
| `SimplePriorityQueue.cs` | Part 2: custom min-heap priority queue. |

## Data Structures Used and Why

| Structure | Where | Why |
|---|---|---|
| `List<Issue>` | `IssueRepository` | Issues arrive in order and are read back in order. |
| `SortedDictionary<DateTime, List<LocalEvent>>` | `EventRepository` | Keeps events in date order automatically; used for the event list and date search. |
| `Dictionary<string, List<LocalEvent>>` (hash table) | `EventRepository` | Fast lookup of all events in a category for the category search. |
| `HashSet<string>` and `HashSet<DateTime>` | `EventRepository` | Hold unique categories and dates, so the dropdown and date range never contain duplicates. |
| `Queue<LocalEvent>` | `EventRepository` | Announcements are kept in publication order (first in, first out). The **Next Announcement** button takes the next one from the front and puts it back at the end. |
| `SimplePriorityQueue<LocalEvent, DateTime>` | `EventRepository` | Always returns the soonest event first, whatever order events were added in. Used for upcoming events and as the default recommendations. .NET Framework 4.7.2 has no built-in priority queue, so a small min-heap was written. |
| `Stack<string>` | `EventRepository` | Remembers recent searches so the newest comes out first (last in, first out). Shown as "Recent searches" and used to break ties in the recommendation. |
| `Dictionary<string, int>` | `EventRepository` | Counts how often each category is searched; drives the recommendation. |
| `Dictionary<string, User>` | `UserRepository` | Looks up an account by username in constant time at login. |

## Recommendation Algorithm

1. Every category search is recorded: pushed onto the stack and counted in the
   dictionary.
2. The most-searched category is found. If two categories tie, the one searched
   recently is preferred.
3. Upcoming events in that category are suggested, soonest first.
4. If fewer than five are found, the list is topped up from the priority queue of
   soonest upcoming events (without duplicates).

## Notes

- Data is held in memory only. Reported issues, search history and any accounts you
  register are lost when the application closes (the demo account is recreated each start). The ten sample events are loaded each time it starts.
- Keep a copy of this project: the PoE builds on this code to add Service Request Status.
