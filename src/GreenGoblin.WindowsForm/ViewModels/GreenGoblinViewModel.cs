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

        public event EventHandler<QuestionEventArgs> Question;

        public GreenGoblinViewModel(IGreenGoblinRepository repository)
        {
            _repository = repository;

            _worker.DoWork += Worker_DoWork;
            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
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

        public string TaskCategory
        {
            get => _taskCategory;
            set
            {
                _taskCategory = value;
                OnPropertyChanged(nameof(TaskCategory));
            }
        }

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

        public void Archive(string fileName)
        {
            var timeEntries = new List<TimeEntry>();
            foreach (var timeEntryModel in SelectedTimeEntryModels)
            {
                timeEntries.Add(new TimeEntry(timeEntryModel.Id, timeEntryModel.StartDateTime, timeEntryModel.EndDateTime, timeEntryModel.Description, timeEntryModel.Category));
            }

            _repository.Archive(timeEntries, fileName);
        }

        public void EndOfDay()
        {
            ActiveModel.EndDateTime = DateTime.Now;
            PendingChanges = true;
            ActiveModel = null;
            SaveBackup();
        }

        public void Load()
        {
            if (PendingChanges)
            {
                var qea =
                    new QuestionEventArgs
                        {
                            Question = "There are pending changes. Would you like to save?",
                            Caption = "Pending Changes"
                        };
                OnQuestion(qea);
                if (qea.Answer)
                {
                    Save();
                }
            }

            if (_repository.CheckBackupFile())
            {
                var qea = new QuestionEventArgs
                              {
                                  Question = "A backup file exists. Would you like to load from the backup file?",
                                  Caption = "Load Backup File"
                              };
                if (qea.Answer)
                {
                    LoadBackupFile = true;
                }
            }

            Loading = true;
            _worker.RunWorkerAsync();
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
            TaskCategory = "Off the Clock";
            StartTask();
            SaveBackup();
        }

        public void StartLunch()
        {
            TaskDescription = "LUNCH";
            TaskCategory = "Off the Clock";
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

            var model = new TimeEntryModel(0, DateTime.Now, DateTime.MaxValue, TaskDescription, TaskCategory);
            TimeEntryModels.Add(model);
            TaskDescription = string.Empty;
            TaskCategory = string.Empty;
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

            if (total.Days > 0)
            {
                var hours = (total.Days * 24) + total.Hours;
                SelectedTaskTime = $"{hours}:{total.Minutes}";
            }
            else
            {
                SelectedTaskTime = total.ToString("hh':'mm");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnQuestion(QuestionEventArgs e)
        {
            Question?.Invoke(this, e);
        }

        private void Reset()
        {
            TaskDescription = string.Empty;
            TaskCategory = string.Empty;
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

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (LoadBackupFile)
            {
                _timeEntries = _repository.LoadBackupTime().OrderByDescending(x => x.StartDateTime).ToList();
                return;
            }

            _timeEntries = _repository.LoadTime().OrderByDescending(x => x.StartDateTime).ToList();
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        private TimeEntryModel _activeModel;
        private bool _loading;
        private bool _pendingChanges;
        private readonly IGreenGoblinRepository _repository;
        private string _selectedTaskTime;
        private List<TimeEntryModel> _selectedTimeEntryModels;
        private string _taskCategory;
        private string _taskDescription;
        private List<TimeEntry> _timeEntries = new List<TimeEntry>();
        private BindingList<TimeEntryModel> _timeEntryModel;
        private readonly BackgroundWorker _worker = new BackgroundWorker();
    }
}