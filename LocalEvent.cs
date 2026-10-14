using System;

namespace MunicipalServicesApp
{
    /// <summary>
    /// Represents a single local event or municipal announcement.
    /// Named "LocalEvent" (rather than "Event") to avoid clashing with the
    /// C# "event" keyword and the System.EventArgs/EventHandler types used
    /// throughout the WinForms designer code.
    /// </summary>
    public class LocalEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Title + " (" + Category + ") - " + Date.ToString("dd MMM yyyy");
        }
    }
}
