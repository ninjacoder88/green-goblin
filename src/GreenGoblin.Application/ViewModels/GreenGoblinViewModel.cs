using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GreenGoblin.WindowsFormApplication.Models;

namespace GreenGoblin.WindowsFormApplication.ViewModels
{
    public class GreenGoblinViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public GreenGoblinViewModel()
        {
        }

        public BindingList<CategoryModel> Categories => _categories ?? (_categories = new BindingList<CategoryModel>());

        public bool LoadBackupFile { get; set; }

        public bool PendingChanges { get; set; }

        public CategoryModel SelectedCategory { get; set; }

        public List<TaskModel> SelectedTasks => _selectedTasks ?? (_selectedTasks = new List<TaskModel>());

        public List<WorkDayModel> SelectedWorkDays => _selectedWorkDays ?? (_selectedWorkDays = new List<WorkDayModel>());

        public string TaskName
        {
            get => _taskName;
            set
            {
                _taskName = value;
                OnPropertyChanged();
            }
        }

        public BindingList<WorkDayModel> WorkDays => _workDays ?? (_workDays = new BindingList<WorkDayModel>());

        public BindingList<TaskModel> WorkDayTasks => _tasks ?? (_tasks = new BindingList<TaskModel>());

        public bool CheckBackupFile()
        {
            return false;
        }

        public void EndTask()
        {
        }

        public void FinishLoading()
        {
        }

        public void Load()
        {
        }

        public void Save()
        {
        }

        public void SaveCategories()
        {
        }

        public void StartLoading()
        {
        }

        public void StartTask()
        {
        }

        public void UpdateSelectedTasks(List<TaskModel> taskModels)
        {
            SelectedTasks.Clear();

            SelectedTasks.AddRange(taskModels);
        }

        public void UpdateSelectedWorkDays(List<WorkDayModel> workDayModels)
        {
            SelectedWorkDays.Clear();

            SelectedWorkDays.AddRange(workDayModels);

            foreach (var workDayModel in workDayModels)
            {
                foreach (var taskModel in workDayModel.Tasks)
                {
                    WorkDayTasks.Add(taskModel);
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BindingList<CategoryModel> _categories;
        private List<TaskModel> _selectedTasks;
        private List<WorkDayModel> _selectedWorkDays;
        private string _taskName;
        private BindingList<TaskModel> _tasks;
        private BindingList<WorkDayModel> _workDays;
    }
}