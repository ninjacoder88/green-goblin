using System;

namespace GreenGoblin.Repository
{
    public class TimeEntry
    {
        public TimeEntry(DateTime startDateTime, DateTime? endDateTime, string description, string category)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            Category = category;
        }

        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}