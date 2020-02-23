using System;
using System.ComponentModel;

namespace GreenGoblin.WindowsForm
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
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Duration => DurationTimeSpan.ToString("hh':'mm");

        public TimeSpan DurationTimeSpan =>  EndDateTime.IsMaxDateTime() ? DateTime.Now - StartDateTime : EndDateTime - StartDateTime;

        public DateTime EndDateTime
        {
            get => _endDateTime;
            set
            {
                _endDateTime = value;
                OnPropertyChanged(nameof(EndDateTime));
                OnPropertyChanged(nameof(Duration));
                OnPropertyChanged(nameof(EndTime));
            }
        }

        public string EndTime => EndDateTime.IsMaxDateTime() ? string.Empty : EndDateTime.ToString("yyyy-MM-dd hh:mm tt");

        public int Id { get; private set; }

        public bool OverlapWarning
        {
            get => _overlapWarning;
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
            get => _reconciled;
            set
            {
                _reconciled = value;
                OnPropertyChanged(nameof(Reconciled));
            }
        }

        public DateTime StartDateTime
        {
            get => _startDateTime;
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