using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GreenGoblin.Repository
{
    public class GreenGoblinFileRepository : IGreenGoblinRepository
    {
        private readonly string _filePath;

        public GreenGoblinFileRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<TimeEntry> Load()
        {
            if (!File.Exists(_filePath))
            {
                var stream = File.Create(_filePath);
                stream.Close();
            }

            var fileLines = File.ReadAllLines(_filePath).ToList();

            var timeEntries = new List<TimeEntry>();

            foreach (var fileLine in fileLines)
            {
                var splitFileLine = fileLine.Split(new[] {","}, StringSplitOptions.None);

                var id = int.Parse(splitFileLine[0]);
                var startTime = DateTime.Parse(splitFileLine[1]);
                var endTime = splitFileLine[2];
                var description = splitFileLine[3];
                var category = splitFileLine[4];

                DateTime? parsedEndTime = null;
                if (!string.IsNullOrEmpty(endTime))
                {
                    parsedEndTime = DateTime.Parse(endTime);
                }

                timeEntries.Add(new TimeEntry(id, startTime, parsedEndTime, description, category));
            }

            return timeEntries;
        }

        public void Save(IEnumerable<TimeEntry> timeEntries)
        {
            var fileLines = new List<string>();
            var timeEntryList = timeEntries.ToList();

            int nextId = timeEntryList.Max(x => x.TimeEntryId) + 1;

            foreach (var timeEntry in timeEntryList)
            {
                if (timeEntry.TimeEntryId == 0)
                {
                    var prop = timeEntry.GetType().GetProperty("TimeEntryId", BindingFlags.Public | BindingFlags.Instance);
                    prop.SetValue(timeEntry, nextId++);
                }

                 fileLines.Add($"{timeEntry.TimeEntryId},{timeEntry.StartDateTime},{timeEntry.EndDateTime},{timeEntry.Description},{timeEntry.Category}");
            }

            File.WriteAllLines(_filePath, fileLines);
        }
    }
}