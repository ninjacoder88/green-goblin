using System;

namespace GreenGoblin.Repository.Entities
{
    internal class TaskEntity
    {
        //public TaskEntity(int taskId, DateTime startDateTime, DateTime? endDateTime, string description, string category)
        //{
        //    TaskId = taskId;
        //    StartDateTime = startDateTime;
        //    EndDateTime = endDateTime;
        //    Description = description;
        //    Category = category;
        //}

        public int TaskId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public bool Archived { get; set; }

        public bool Reconciled { get; set; }
    }
}