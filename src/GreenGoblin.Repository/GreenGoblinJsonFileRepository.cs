using System.Collections.Generic;
using System.IO;
using System.Linq;
using GreenGoblin.Repository.Entities;
using GreenGoblin.Repository.Models;
using Newtonsoft.Json;

namespace GreenGoblin.Repository
{
    public class GreenGoblinJsonFileRepository
    {
        public GreenGoblinJsonFileRepository(string directory)
        {
            _directory = directory;
            _currentTasksFilePath = Path.Combine(directory, "gg-tasks.json");
            _categoriesFilePath = Path.Combine(directory, "gg-categories.json");
            //_backupTasksFilePath = Path.Combine(directory, "greengoblin.backup.json");
        }

        public IEnumerable<TaskModel> LoadCurrentTasks()
        {
            return LoadTasks(_currentTasksFilePath);
        }

        public IEnumerable<CategoryModel> LoadCategories()
        {
            return LoadCategories(_categoriesFilePath);
        }

        public void SaveCategories(IEnumerable<CategoryModel> categoryModels)
        {
            var categoryModelList = categoryModels.ToList();

            int nextId = categoryModelList.Max(x => x.CategoryId) + 1;

            var entities = new List<CategoryModel>();
            foreach (var categoryModel in categoryModelList)
            {
                entities.Add(new CategoryModel
                                 {
                                     CategoryId = categoryModel.CategoryId == 0 ? nextId++ : categoryModel.CategoryId,
                                     CategoryName = categoryModel.CategoryName
                                 });
            }

            var fileText = JsonConvert.SerializeObject(entities);

            File.WriteAllText(_categoriesFilePath, fileText);
        }

        public void SaveTasks(IEnumerable<TaskModel> taskModels)
        {
            var taskModelsList = taskModels.ToList();

            int nextId = taskModelsList.Max(x => x.TaskId) + 1;

            var entities = new List<TaskEntity>();
            foreach (var taskModel in taskModelsList)
            {
                entities.Add(new TaskEntity
                                 {
                                     Description = taskModel.Description,
                                     TaskId = taskModel.TaskId == 0 ? nextId++ : taskModel.TaskId,
                                     EndDateTime = taskModel.EndDateTime,
                                     StartDateTime = taskModel.StartDateTime,
                                     Archived = taskModel.Archived,
                                     Category = taskModel.Category,
                                     Reconciled = taskModel.Reconciled
                                 });
            }

            var fileText = JsonConvert.SerializeObject(entities);

            File.WriteAllText(_currentTasksFilePath, fileText);
            //File.Delete(_backupTasksFilePath);
        }

        private IEnumerable<CategoryModel> LoadCategories(string filePath)
        {
            string fileText = LoadOrCreate(filePath);
            var categoryEntities = JsonConvert.DeserializeObject<List<CategoryEntity>>(fileText);

            var models = new List<CategoryModel>();
            foreach (var categoryEntity in categoryEntities)
            {
                models.Add(new CategoryModel
                               {
                                   CategoryName = categoryEntity.CategoryName,
                                   CategoryId = categoryEntity.CategoryId
                               });
            }

            return models;
        }

        private string LoadOrCreate(string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (var stream = File.Create(filePath))
                {
                    stream.Close();
                }
            }

            return File.ReadAllText(filePath);
        }

        private IEnumerable<TaskModel> LoadTasks(string filePath)
        {
            string fileText = LoadOrCreate(filePath);
            var taskEntities = JsonConvert.DeserializeObject<List<TaskEntity>>(fileText);

            var models = new List<TaskModel>();
            foreach (var taskEntity in taskEntities)
            {
                models.Add(new TaskModel
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

        private string _categoriesFilePath;
        private readonly string _currentTasksFilePath;
        private readonly string _directory;
    }
}