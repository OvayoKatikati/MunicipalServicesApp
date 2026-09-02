using System;
using System.Collections.Generic;

namespace MunicipalServicesApp
{
 
    // Represents a single municipal service issue reported by a resident.
   
    public class Issue
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public List<string> AttachmentPaths { get; set; }
        public DateTime DateReported { get; set; }

        public Issue()
        {
            AttachmentPaths = new List<string>();
            DateReported = DateTime.Now;
        }
    }
}
