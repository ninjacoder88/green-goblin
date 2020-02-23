using System.Collections.Generic;
using GreenGoblin.Repository.Models;

namespace GreenGoblin.Repository
{
    public class GreenGoblinDatabaseRepository : IGreenGoblinRepository
    {
        public void Archive(IEnumerable<TaskModel> timeEntries, string fileName)
        {
        }

        public bool CheckBackupFile()
        {
            return false;
        }

        public IEnumerable<TaskModel> LoadBackupTime()
        {
            yield break;
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            yield break;
        }

        public IEnumerable<TaskModel> LoadTime()
        {
            yield break;
        }

        public void Save(IEnumerable<TaskModel> timeEntries)
        {
        }

        public void SaveBackup(IEnumerable<TaskModel> timeEntries)
        {
        }
    }
}