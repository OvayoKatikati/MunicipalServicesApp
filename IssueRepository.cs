using System.Collections.Generic;

namespace MunicipalServicesApp
{
    public static class IssueRepository
    {
        private static readonly List<Issue> _issues = new List<Issue>();
        private static int _nextId = 1;

        public static IReadOnlyList<Issue> Issues => _issues.AsReadOnly();

        public static Issue AddIssue(string location, string category, string description, List<string> attachments)
        {
            var issue = new Issue
            {
                Id = _nextId++,
                Location = location,
                Category = category,
                Description = description,
                AttachmentPaths = attachments ?? new List<string>()
            };

            _issues.Add(issue);
            return issue;
        }

        public static int Count => _issues.Count;
    }
}
