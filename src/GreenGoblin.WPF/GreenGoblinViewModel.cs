using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GreenGoblin.WPF
{
    public class GreenGoblinViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string TextDescription { get; set; }

        public ObservableCollection<TimeEntryModel> TimeEntryModels => _timeEntryModels ?? (_timeEntryModels = new ObservableCollection<TimeEntryModel>());

        public void EndDay()
        {
        }

        public void FinishLoading()
        {
        }

        public void Load()
        {
            TimeEntryModels.Add(new TimeEntryModel(1, DateTime.Now, DateTime.MaxValue, "Task", "Something"));
        }

        public void Reconcile()
        {
        }

        public void RemoveEntry()
        {
        }

        public void Save()
        {
        }

        public void StartBreak()
        {
        }

        public void StartLoading()
        {
        }

        public void StartLunch()
        {
        }

        public void StartTask()
        {
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<TimeEntryModel> _timeEntryModels;
    }
}