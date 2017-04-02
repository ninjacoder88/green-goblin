using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace GreenGoblin.WindowsForm
{
    public class GreenGoblinViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedTaskTime
        {
            get { return _selectedTaskTime; }
            set
            {
                _selectedTaskTime = value;
                OnPropertyChanged(nameof(SelectedTaskTime));
            }
        }

        public List<TimeEntryModel> SelectedTimeEntryModels => _selectedTimeEntryModels ?? (_selectedTimeEntryModels = new List<TimeEntryModel>());

        public string TaskDescription
        {
            get { return _taskDescription; }
            set
            {
                _taskDescription = value;
                OnPropertyChanged(nameof(TaskDescription));
            }
        }

        public BindingList<TimeEntryModel> TimeEntryModels => _timeEntryModel ?? (_timeEntryModel = new BindingList<TimeEntryModel>());

        private TimeEntryModel ActiveModel { get; set; }

        public void EndOfDay()
        {
            ActiveModel.EndDateTime = DateTime.Now;
        }

        public void StartBreak()
        {
            TaskDescription = "ON BREAK";
            StartTask();
        }

        public void StartLunch()
        {
            TaskDescription = "LUNCH";
            StartTask();
        }

        public void StartTask()
        {
            if (string.IsNullOrEmpty(TaskDescription))
            {
                return;
            }

            if (ActiveModel != null)
            {
                ActiveModel.EndDateTime = DateTime.Now;
            }

            var model = new TimeEntryModel {StartDateTime = DateTime.Now, Description = TaskDescription, Category = string.Empty};
            TimeEntryModels.Add(model);
            TaskDescription = string.Empty;
            ActiveModel = model;
        }

        public void UpdateSelectedModels(List<TimeEntryModel> selectedModels)
        {
            SelectedTimeEntryModels.Clear();
            SelectedTimeEntryModels.AddRange(selectedModels);

            TimeSpan total = TimeSpan.Zero;
            foreach (var timeEntryModel in selectedModels)
            {
                if (timeEntryModel.EndDateTime == null)
                {
                    total = total.Add(DateTime.Now - timeEntryModel.StartDateTime);
                    continue;
                }
                total = total.Add(timeEntryModel.DurationTimeSpan);
            }

            SelectedTaskTime = total.ToString("hh':'mm");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _selectedTaskTime;
        private List<TimeEntryModel> _selectedTimeEntryModels;
        private string _taskDescription;
        private BindingList<TimeEntryModel> _timeEntryModel;
    }
}