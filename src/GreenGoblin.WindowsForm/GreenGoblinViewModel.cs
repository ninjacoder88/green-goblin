using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GreenGoblin.WindowsForm
{
    public class GreenGoblinViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public GreenGoblinViewModel(IGreenGoblinRepository repository)
        {
            _repository = repository;
        }

        public bool PendingChanges
        {
            get { return _pendingChanges; }
            private set
            {
                _pendingChanges = value;
                OnPropertyChanged(nameof(PendingChanges));
            }
        }

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
            PendingChanges = true;
        }

        public void Load()
        {
            Reset();

            var models = _repository.LoadModels().ToList();

            foreach (var timeEntryModel in models)
            {
                var model = new TimeEntryModel(timeEntryModel.StartDateTime, timeEntryModel.EndDateTime, timeEntryModel.Description, timeEntryModel.Category);
                TimeEntryModels.Add(model);
            }

            PendingChanges = false;
        }

        public void Reconcile()
        {
            foreach (var selectedTimeEntryModel in SelectedTimeEntryModels)
            {
                selectedTimeEntryModel.Reconciled = true;
            }
        }

        public void RemoveEntry()
        {
            if (!SelectedTimeEntryModels.Any())
            {
                return;
            }

            foreach (var selectedTimeEntryModel in SelectedTimeEntryModels)
            {
                TimeEntryModels.Remove(selectedTimeEntryModel);
            }

            PendingChanges = true;
        }

        public void Save()
        {
            _repository.Save(TimeEntryModels);

            PendingChanges = false;
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

            var model = new TimeEntryModel(DateTime.Now, null, TaskDescription, string.Empty);
            TimeEntryModels.Add(model);
            TaskDescription = string.Empty;
            ActiveModel = model;
            PendingChanges = true;
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

        private void Reset()
        {
            TaskDescription = string.Empty;
            SelectedTaskTime = string.Empty;
            SelectedTimeEntryModels.Clear();
            TimeEntryModels.Clear();
            ActiveModel = null;
        }

        private bool _pendingChanges;
        private readonly IGreenGoblinRepository _repository;
        private string _selectedTaskTime;
        private List<TimeEntryModel> _selectedTimeEntryModels;
        private string _taskDescription;
        private BindingList<TimeEntryModel> _timeEntryModel;
    }
}