using System.Collections.Generic;

namespace GreenGoblin.Repository
{
    public interface IGreenGoblinRepository
    {
        bool CheckBackupFile();

        IEnumerable<TimeEntry> LoadBackupTime();

        IEnumerable<TimeEntry> LoadTime();

        void Save(IEnumerable<TimeEntry> timeEntries);

        void SaveBackup(IEnumerable<TimeEntry> timeEntries);
    }
}