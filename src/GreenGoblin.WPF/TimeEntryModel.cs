using System;
using System.ComponentModel;

namespace GreenGoblin.WPF
{
    public class TimeEntryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TimeEntryModel(int id, DateTime startTime, DateTime endTime, string description, string category)
        {
            Id = id;
            _startDateTime = startTime;
            _endDateTime = endTime;
            _description = description;
            _category = category;
        }

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

        public TimeSpan DurationTimeSpan => EndDateTime == DateTime.MaxValue ? DateTime.Now - StartDateTime : EndDateTime - StartDateTime;

        public DateTime EndDateTime
        {
            get { return _endDateTime; }
            set
            {
                _endDateTime = value;
                OnPropertyChanged(nameof(EndDateTime));
                OnPropertyChanged(nameof(Duration));
                OnPropertyChanged(nameof(EndTime));
            }
        }

        public string EndTime => EndDateTime == DateTime.MaxValue ? string.Empty : EndDateTime.ToString("yyyy-MM-dd hh:mm tt");

        public int Id { get; private set; }

        public bool OverlapWarning
        {
            get { return _overlapWarning; }
            set
            {
                if (value == _overlapWarning)
                {
                    return;
                }
                _overlapWarning = value;
                OnPropertyChanged(nameof(OverlapWarning));
            }
        }

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
                OnPropertyChanged(nameof(StartTime));
            }
        }

        public string StartTime => StartDateTime.ToString("yyyy-MM-dd hh:mm tt");

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _category;
        private string _description;
        private DateTime _endDateTime;
        private bool _overlapWarning;
        private bool _reconciled;
        private DateTime _startDateTime;
    }
}