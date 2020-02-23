using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GreenGoblin.Repository.Entities;
using GreenGoblin.Repository.Models;
using Newtonsoft.Json;

namespace GreenGoblin.Repository
{
    public class GreenGoblinJsonFileRepository
    {
        private readonly string _directory;
        private string _currentTasksFilePath;
        private string _backupTasksFilePath;

        private string _categoriesFilePath;


        public GreenGoblinJsonFileRepository(string directory)
        {
            _directory = directory;
            _currentTasksFilePath = Path.Combine(directory, "greengoblin.json");
            _backupTasksFilePath = Path.Combine(directory, "greengoblin.backup.json");
        }

        public IEnumerable<TaskModel> LoadCurrentTasks()
        {
            return Load(_currentTasksFilePath);
        }

        public IEnumerable<TaskModel> LoadBackupTasks()
        {
            return Load(_backupTasksFilePath);
        }

        public void Save(IEnumerable<TaskModel> taskModels)
        {
            var taskModelsList = taskModels.ToList();

            int nextId = taskModelsList.Max(x => x.TaskId) + 1;

            List<TaskEntity> entities = new List<TaskEntity>();
            foreach (var taskModel in taskModelsList)
            {
                entities.Add(new TaskEntity()
                                 {
                                     Description = taskModel.Description,
                                     TaskId = 1,
                                     EndDateTime = taskModel.EndDateTime,
                                     StartDateTime = taskModel.StartDateTime,
                                     Archived = taskModel.Archived,
                                     Category = taskModel.Category,
                                     Reconciled = taskModel.Reconciled
                                 });
            }

            var fileText = JsonConvert.SerializeObject(entities);

            File.WriteAllText(_currentTasksFilePath, fileText);
            File.Delete(_backupTasksFilePath);
        }

        private IEnumerable<TaskModel> Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (var stream = File.Create(filePath))
                {
                    stream.Close();
                }
            }

            string fileText = File.ReadAllText(filePath);
            var taskEntities = JsonConvert.DeserializeObject<List<TaskEntity>>(fileText);

            var models = new List<TaskModel>();
            foreach (var taskEntity in taskEntities)
            {
                models.Add(new TaskModel()
                               {
                                   Archived = taskEntity.Archived,
                                   Category = taskEntity.Category,
                                   Description = taskEntity.Description,
                                   EndDateTime = taskEntity.EndDateTime,
                                   Reconciled = taskEntity.Reconciled,
                                   StartDateTime = taskEntity.StartDateTime,
                                   TaskId = taskEntity.TaskId
                               });
            }

            return models;
        }
    }
}