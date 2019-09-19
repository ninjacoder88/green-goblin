using System;
using System.Collections.Generic;
using System.Threading;

namespace GreenGoblin.Repository
{
    public class TestingRepository : IGreenGoblinRepository
    {
        public void Archive(IEnumerable<TimeEntry> timeEntries, string fileName)
        {
        }

        public bool CheckBackupFile()
        {
            return false;
        }

        public IEnumerable<TimeEntry> LoadBackupTime()
        {
            yield break;
        }

        public IEnumerable<TimeEntry> LoadTime()
        {
            Thread.Sleep(5000);

            var entries =
                new List<TimeEntry>
                    {
                        new TimeEntry(1, new DateTime(2017, 04, 01, 6, 30, 12), new DateTime(2017, 04, 01, 6, 45, 12),
                                      "Support Ticket", string.Empty)
                    };

            return entries;
        }

        public void Save(IEnumerable<TimeEntry> timeEntries)
        {
        }

        public void SaveBackup(IEnumerable<TimeEntry> timeEntries)
        {
        }
    }
}