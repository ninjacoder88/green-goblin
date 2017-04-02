using System;
using System.ComponentModel;

namespace GreenGoblin.WindowsForm
{
    public class TimeEntryModel : INotifyPropertyChanged
    {
        public TimeEntryModel(DateTime startTime, DateTime? endTime, string description, string category)
        {
            _startDateTime = startTime;
            _endDateTime = endTime;
            _description = description;
            _category = category;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Duration => DurationTimeSpan.ToString("hh':'mm");

        public TimeSpan DurationTimeSpan => EndDateTime == null ? DateTime.Now - StartDateTime : EndDateTime.Value - StartDateTime;

        public DateTime? EndDateTime
        {
            get { return _endDateTime; }
            set
            {
                _endDateTime = value;
                OnPropertyChanged(nameof(EndDateTime));
                OnPropertyChanged(nameof(Duration));
            }
        }

        public string EndTime => EndDateTime?.ToString("yyyy-MM-dd hh:mm tt") ?? string.Empty;

        public bool Reconciled
        {
            get { return _reconciled; }
            set
            {
                _reconciled = value;
                OnPropertyChanged(nameof(Reconciled));
            }
        }

        public DateTime StartDateTime
        {
            get { return _startDateTime; }
            set
            {
                _startDateTime = value;
                OnPropertyChanged(nameof(StartDateTime));
                OnPropertyChanged(nameof(Duration));
            }
        }

        public string StartTime => StartDateTime.ToString("yyyy-MM-dd hh:mm tt");

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _category;
        private string _description;
        private DateTime? _endDateTime;
        private bool _reconciled;
        private DateTime _startDateTime;
    }
}