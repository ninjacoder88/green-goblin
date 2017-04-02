using System;

namespace GreenGoblin.Repository
{
    public class TimeEntry
    {
        public TimeEntry(int timeEntryId, DateTime startDateTime, DateTime? endDateTime, string description, string category)
        {
            TimeEntryId = timeEntryId;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Description = description;
            Category = category;
        }

        public int TimeEntryId { get; private set; }

        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}