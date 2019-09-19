using System.Collections.Generic;

namespace GreenGoblin.Repository
{
    public class GreenGoblinDatabaseRepository : IGreenGoblinRepository
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
            yield break;
        }

        public void Save(IEnumerable<TimeEntry> timeEntries)
        {
        }

        public void SaveBackup(IEnumerable<TimeEntry> timeEntries)
        {
        }
    }
}