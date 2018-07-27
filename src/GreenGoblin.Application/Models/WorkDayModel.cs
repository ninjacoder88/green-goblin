using System;
using System.ComponentModel;

namespace GreenGoblin.WindowsFormApplication.Models
{
    public class WorkDayModel
    {
        public string DayTimeStamp => TimeStamp.ToString("yyyy-MM-dd");

        public BindingList<TaskModel> Tasks => _tasks ?? (_tasks = new BindingList<TaskModel>());

        public DateTime TimeStamp { get; set; }

        private BindingList<TaskModel> _tasks;
    }
}