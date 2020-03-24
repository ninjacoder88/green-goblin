using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GreenGoblin.Repository.Models;

namespace GreenGoblin.Repository
{
    public class GreenGoblinFileRepository : IGreenGoblinRepository
    {
        public GreenGoblinFileRepository(string directory)
        {
            _directory = directory;
            _filePath = Path.Combine(directory, "time.txt");
            _backupFilePath = Path.Combine(directory, "time.backup.txt");
            _categoriesFilePath = Path.Combine(directory, "categories.txt");
        }

        public void Archive(IEnumerable<TaskModel> timeEntries, string fileName)
        {
            var fileLines = new List<string>();
            var timeEntryList = timeEntries.ToList();

            int nextId = timeEntryList.Max(x => x.TaskId) + 1;

            foreach (var timeEntry in timeEntryList)
            {
                int id = timeEntry.TaskId == 0 ? nextId++ : timeEntry.TaskId;

                fileLines.Add($"{id},{timeEntry.StartDateTime},{timeEntry.EndDateTime},{timeEntry.Description},{timeEntry.Category}");
            }

            string archiveFilePath = Path.Combine(_directory, $"{fileName}.txt");
            File.WriteAllLines(archiveFilePath, fileLines);
        }

        public bool CheckBackupFile()
        {
            return File.Exists(_backupFilePath);
        }

        public IEnumerable<TaskModel> LoadBackupTime()
        {
            return Load(_backupFilePath);
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            var fileLines = LoadOrCreate(_categoriesFilePath);

            var categoryModels = new List<CategoryModel>();
            foreach (var fileLine in fileLines)
            {
                var splitFileLine = fileLine.Split(new[] {","}, StringSplitOptions.None);

                var id = int.Parse(splitFileLine[0]);
                var name = splitFileLine[1];

                categoryModels.Add(new CategoryModel
                                       {
                                           CategoryId = id,
                                           CategoryName = name
                                       });
            }

            return categoryModels;
        }

        public IEnumerable<TaskModel> LoadTime()
        {
            return Load(_filePath);
        }

        public void Save(IEnumerable<TaskModel> timeEntries)
        {
            var fileLines = new List<string>();
            var timeEntryList = timeEntries.ToList();

            if (timeEntryList.Any())
            {
                int nextId = timeEntryList.Max(x => x.TaskId) + 1;

                foreach (var timeEntry in timeEntryList)
                {
                    int id = timeEntry.TaskId == 0 ? nextId++ : timeEntry.TaskId;

                    fileLines.Add($"{id},{timeEntry.StartDateTime},{timeEntry.EndDateTime},{timeEntry.Description},{timeEntry.Category}");
                }
            }

            File.WriteAllLines(_filePath, fileLines);
            File.Delete(_backupFilePath);
        }

        public void SaveBackup(IEnumerable<TaskModel> timeEntries)
        {
            if (!File.Exists(_backupFilePath))
            {
                var stream = File.Create(_backupFilePath);
                stream.Close();
            }

            var fileLines = new List<string>();
            var timeEntryList = timeEntries.ToList();

            if (timeEntryList.Any())
            {
                int nextId = timeEntryList.Max(x => x.TaskId) + 1;

                foreach (var timeEntry in timeEntryList)
                {
                    int id = timeEntry.TaskId == 0 ? nextId++ : timeEntry.TaskId;

                    fileLines.Add($"{id},{timeEntry.StartDateTime},{timeEntry.EndDateTime},{timeEntry.Description},{timeEntry.Category}");
                }
            }

            File.WriteAllLines(_backupFilePath, fileLines);
        }

        private IEnumerable<TaskModel> Load(string filePath)
        {
            var fileLines = LoadOrCreate(filePath);

            var timeEntries = new List<TaskModel>();

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

                timeEntries.Add(new TaskModel
                                    {
                                        TaskId = id,
                                        StartDateTime = startTime,
                                        EndDateTime = parsedEndTime,
                                        Description = description,
                                        Category = category
                                    });
            }

            return timeEntries;
        }

        private List<string> LoadOrCreate(string filePath)
        {
            if (!File.Exists(filePath))
            {
                var stream = File.Create(filePath);
                stream.Close();
            }

            return File.ReadAllLines(filePath).ToList();
        }

        private readonly string _backupFilePath;
        private readonly string _categoriesFilePath;
        private readonly string _directory;
        private readonly string _filePath;
    }
}