using System.ComponentModel;

namespace GreenGoblin.WindowsForm
{
    public class GreenGoblinViewModel
    {
        public BindingList<TimeEntryModel> TimeEntryModels => _timeEntryModel ?? (_timeEntryModel = new BindingList<TimeEntryModel>());

        private BindingList<TimeEntryModel> _timeEntryModel;

        public string TaskDescription { get; set; }

        public void StartTask()
        {
        }

        public void StartLunch()
        {
        }

        public void EndOfDay()
        {
        }

        public void StartBreak()
        {
        }
    }
}