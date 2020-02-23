using System;
using System.Collections.Generic;
using System.Threading;
using GreenGoblin.Repository.Models;

namespace GreenGoblin.Repository
{
    public class TestingRepository : IGreenGoblinRepository
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
            Thread.Sleep(5000);

            var entries =
                new List<TaskModel>
                    {
                        new TaskModel()
                            {
                                TaskId = 1,
                                StartDateTime = new DateTime(2017, 04, 01, 6, 30, 12),
                                EndDateTime = new DateTime(2017, 04, 01, 6, 45, 12),
                                Description = "Support Ticket",
                                Category = string.Empty
                            },
                    };

            return entries;
        }

        public void Save(IEnumerable<TaskModel> timeEntries)
        {
        }

        public void SaveBackup(IEnumerable<TaskModel> timeEntries)
        {
        }
    }
}