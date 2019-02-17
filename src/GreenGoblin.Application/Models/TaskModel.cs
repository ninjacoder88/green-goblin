using System;

namespace GreenGoblin.WindowsFormApplication.Models
{
    public class TaskModel
    {
        public string StartDateTimeString { get; set; }

        public string EndDateTimeString { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string TaskName { get; set; }

        public string CategoryName { get; set; }

        public bool Reconciled { get; set; }
    }
}