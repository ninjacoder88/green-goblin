using System.Collections.Generic;
using GreenGoblin.Repository.Models;

namespace GreenGoblin.Repository
{
    public interface IGreenGoblinRepository
    {
        void Archive(IEnumerable<TaskModel> timeEntries, string fileName);

        bool CheckBackupFile();

        IEnumerable<TaskModel> LoadBackupTime();

        IEnumerable<CategoryModel> LoadCategories();

        IEnumerable<TaskModel> LoadTime();

        void Save(IEnumerable<TaskModel> timeEntries);

        void SaveBackup(IEnumerable<TaskModel> timeEntries);
    }
}