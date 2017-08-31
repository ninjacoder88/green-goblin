using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GreenGoblin.Repository;

namespace GreenGoblin.WindowsForm
{
    public class GreenGoblinViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public GreenGoblinViewModel(IGreenGoblinRepository repository)
        {
            _repository = repository;
        }

        public bool ActiveModelOpen => ActiveModel != null;

        public bool LoadBackupFile { get; set; }

        public bool Loading
        {
            get => _loading;
            private set
            {
                _loading = value;
                OnPropertyChanged(nameof(Loading));
                OnPropertyChanged(nameof(NotLoading));
            }
        }

        public bool NotLoading => !Loading;

        public bool PendingChanges
        {
            get => _pendingChanges;
            private set
            {
                _pendingChanges = value;
                OnPropertyChanged(nameof(PendingChanges));
            }
        }

        public string SelectedTaskTime
        {
            get => _selectedTaskTime;
            set
            {
                _selectedTaskTime = value;
                OnPropertyChanged(nameof(SelectedTaskTime));
            }
        }

        public List<TimeEntryModel> SelectedTimeEntryModels => _selectedTimeEntryModels ?? (_selectedTimeEntryModels = new List<TimeEntryModel>());

        public string TaskDescription
        {
            get => _taskDescription;
            set
            {
                _taskDescription = value;
                OnPropertyChanged(nameof(TaskDescription));
            }
        }

        public BindingList<TimeEntryModel> TimeEntryModels => _timeEntryModel ?? (_timeEntryModel = new BindingList<TimeEntryModel>());

        private TimeEntryModel ActiveModel
        {
            get => _activeModel;
            set
            {
                _activeModel = value;
                OnPropertyChanged(nameof(ActiveModelOpen));
            }
        }

        public bool CheckBackupFile()
        {
            return _repository.CheckBackupFile();
        }

        public void EndOfDay()
        {
            ActiveModel.EndDateTime = DateTime.Now;
            PendingChanges = true;
            ActiveModel = null;
            SaveBackup();
        }

        public void FinishLoading()
        {
            Reset();

            foreach (var timeEntry in _timeEntries)
            {
                var model = new TimeEntryModel(timeEntry.TimeEntryId, timeEntry.StartDateTime, timeEntry.EndDateTime ?? DateTime.MaxValue, timeEntry.Description,
                                               timeEntry.Category);
                TimeEntryModels.Add(model);
            }

            ActiveModel = TimeEntryModels.FirstOrDefault(x => x.EndDateTime.IsMaxDateTime());

            PendingChanges = LoadBackupFile;
            Loading = false;
            LoadBackupFile = false;
        }

        public void Load()
        {
            if (LoadBackupFile)
            {
                _timeEntries = _repository.LoadBackupTime().OrderByDescending(x => x.StartDateTime).ToList();
                return;
            }

            _timeEntries = _repository.LoadTime().OrderByDescending(x => x.StartDateTime).ToList();
        }

        public void ModelEdited(TimeEntryModel model)
        {
            ValidateOverlap();
            PendingChanges = true;
            SaveBackup();
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

            var entriesToRemove = SelectedTimeEntryModels.ToList();
            foreach (var selectedTimeEntryModel in entriesToRemove)
            {
                TimeEntryModels.Remove(selectedTimeEntryModel);
            }

            PendingChanges = true;
            SaveBackup();
        }

        public void Save()
        {
            var timeEntries = new List<TimeEntry>();
            foreach (var timeEntryModel in TimeEntryModels)
            {
                timeEntries.Add(new TimeEntry(timeEntryModel.Id, timeEntryModel.StartDateTime, timeEntryModel.EndDateTime, timeEntryModel.Description, timeEntryModel.Category));
            }

            _repository.Save(timeEntries);

            PendingChanges = false;
        }

        public void StartBreak()
        {
            TaskDescription = "ON BREAK";
            StartTask();
            SaveBackup();
        }

        public void StartLoading()
        {
            Loading = true;
        }

        public void StartLunch()
        {
            TaskDescription = "LUNCH";
            StartTask();
            SaveBackup();
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

            var model = new TimeEntryModel(0, DateTime.Now, DateTime.MaxValue, TaskDescription, string.Empty);
            TimeEntryModels.Add(model);
            TaskDescription = string.Empty;
            ActiveModel = model;
            PendingChanges = true;

            SortModels();
            SaveBackup();
        }

        public void UpdateSelectedModels(List<TimeEntryModel> selectedModels)
        {
            SelectedTimeEntryModels.Clear();
            SelectedTimeEntryModels.AddRange(selectedModels);

            TimeSpan total = TimeSpan.Zero;
            foreach (var timeEntryModel in selectedModels)
            {
                if (timeEntryModel.EndDateTime == DateTime.MaxValue)
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

        private void SaveBackup()
        {
            var timeEntries = new List<TimeEntry>();
            foreach (var timeEntryModel in TimeEntryModels)
            {
                timeEntries.Add(new TimeEntry(timeEntryModel.Id, timeEntryModel.StartDateTime, timeEntryModel.EndDateTime, timeEntryModel.Description, timeEntryModel.Category));
            }

            _repository.SaveBackup(timeEntries);
        }

        private void SortModels()
        {
            var orderedModels = TimeEntryModels.OrderByDescending(x => x.StartDateTime).ToList();
            TimeEntryModels.Clear();
            foreach (var timeEntryModel in orderedModels)
            {
                TimeEntryModels.Add(timeEntryModel);
            }
        }

        private void ValidateOverlap()
        {
            if (TimeEntryModels.Count <= 1)
            {
                return;
            }

            for (int i = 1; i < TimeEntryModels.Count; i++)
            {
                var recent = TimeEntryModels[i - 1];
                var past = TimeEntryModels[i];

                if (recent.StartDateTime < past.EndDateTime)
                {
                    //TODO: fire off event to change color/fix cell formatting event
                    recent.OverlapWarning = true;
                }
                else
                {
                    recent.OverlapWarning = false;
                }
            }
        }

        private TimeEntryModel _activeModel;
        private bool _loading;
        private bool _pendingChanges;
        private readonly IGreenGoblinRepository _repository;
        private string _selectedTaskTime;
        private List<TimeEntryModel> _selectedTimeEntryModels;
        private string _taskDescription;
        private List<TimeEntry> _timeEntries = new List<TimeEntry>();
        private BindingList<TimeEntryModel> _timeEntryModel;
    }
}