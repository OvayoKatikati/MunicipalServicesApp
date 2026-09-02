# Municipal Services Application — Part 1: Report Issues

A C# WinForms (.NET Framework 4.7.2) desktop application for reporting
municipal service issues in South Africa (e.g. sanitation, roads, water,
electricity). This is Part 1 of a three-part project; only the **Report
Issues** feature is implemented here, as required by the brief.

## Requirements

- Windows 10/11
- Visual Studio 2019 or 2022 with the **.NET desktop development** workload
  (includes the .NET Framework 4.7.2 targeting pack)

## How to Compile and Run

1. Extract/copy the `MunicipalServicesApp` folder to your machine.
2. Open **MunicipalServicesApp.sln** in Visual Studio.
3. Let Visual Studio restore/load the project (no NuGet packages are
   required — the app only uses the standard .NET Framework libraries).
4. Press **F5** (or click **Start**) to build and run the application.
   - You can also build only via **Build > Build Solution** (Ctrl+Shift+B),
     then run the compiled `MunicipalServicesApp.exe` from
     `bin\Debug\` or `bin\Release\`.

## How to Use the Application

1. On startup, the **Main Menu** appears with three options:
   - **Report Issues** — enabled and fully functional.
   - **Local Events and Announcements** — disabled (to be implemented in
     Part 2).
   - **Service Request Status** — disabled (to be implemented in the PoE).
2. Click **Report Issues** to open the reporting form.
3. Fill in:
   - **Location** — a text description of where the issue is.
   - **Category** — select from the dropdown (e.g. Sanitation, Roads and
     Potholes, Water and Sewerage, Electricity, Refuse Collection, Public
     Safety, Parks and Recreation, Other).
   - **Description** — a detailed explanation of the issue.
   - **Attach Image / Document** (optional) — opens a file dialog so you can
     attach one or more supporting images/documents.
4. As you complete each field, the **progress bar and message** at the
   bottom update live to show how close you are to a complete report — this
   is the application's user engagement feature.
5. Click **Submit**. If any required field (location, category,
   description) is missing, a warning message box tells you what to fix.
   On success, a confirmation message box shows a reference number and the
   form resets so you can report another issue.
6. Click **Back to Main Menu** at any time to return to the main menu.

## Project Structure

| File | Purpose |
|---|---|
| `Program.cs` | Application entry point. |
| `MainMenuForm.cs` / `.Designer.cs` | Main menu with the three task options. |
| `ReportIssuesForm.cs` / `.Designer.cs` | The Report Issues form and all its event handling / validation / engagement logic. |
| `Issue.cs` | Data model for a single reported issue. |
| `IssueRepository.cs` | In-memory `List<Issue>` store shared across the app for the lifetime of the session. |

## Data Structure Used

Reported issues are stored in a `List<Issue>` inside the static
`IssueRepository` class. A list was chosen because issues are reported
sequentially, order of reporting matters, and a list gives efficient
iteration/searching — which will be built on for filtering and search
functionality in Part 2.

## Notes

- This is an in-memory application: reported issues are **not** saved to a
  file or database and will be lost when the application closes. Persistent
  storage is out of scope for Part 1.
- Keep a copy of this project — Part 2 and the Portfolio of Evidence (PoE)
  build directly on top of this code.
