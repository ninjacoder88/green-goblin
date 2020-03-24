using System;

namespace GreenGoblin.Repository.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public bool Archived { get; set; }

        public bool Reconciled { get; set; }
    }
}