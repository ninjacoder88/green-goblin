using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GreenGoblin.Repository
{
    public class GreenGoblinFileRepository : IGreenGoblinRepository
    {
        public GreenGoblinFileRepository(string filePath, string backupFilePath)
        {
            _filePath = filePath;
            _backupFilePath = backupFilePath;
        }

        public bool CheckBackupFile()
        {
            return File.Exists(_backupFilePath);
        }

        public IEnumerable<TimeEntry> LoadBackupTime()
        {
            return Load(_backupFilePath);
        }

        public IEnumerable<TimeEntry> LoadTime()
        {
            return Load(_filePath);
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
            File.Delete(_backupFilePath);
        }

        public void SaveBackup(IEnumerable<TimeEntry> timeEntries)
        {
            if (!File.Exists(_backupFilePath))
            {
                var stream = File.Create(_backupFilePath);
                stream.Close();
            }

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

            File.WriteAllLines(_backupFilePath, fileLines);
        }

        private IEnumerable<TimeEntry> Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                var stream = File.Create(filePath);
                stream.Close();
            }

            var fileLines = File.ReadAllLines(filePath).ToList();

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

        private readonly string _filePath;
        private readonly string _backupFilePath;
    }
}