using System.Collections.Generic;

namespace GreenGoblin.Repository
{
    public interface IGreenGoblinRepository
    {
        void Archive(IEnumerable<TimeEntry> timeEntries, string fileName);

        bool CheckBackupFile();

        IEnumerable<TimeEntry> LoadBackupTime();

        IEnumerable<TimeEntry> LoadTime();

        void Save(IEnumerable<TimeEntry> timeEntries);

        void SaveBackup(IEnumerable<TimeEntry> timeEntries);
    }
}