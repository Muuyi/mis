using System;
using System.Collections.Generic;
namespace mis.Models
{
    public class Tasks : Base
    {
        public string TaskSubject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Metric { get; set; }
        public string Status { get; set; }
        public string ApplicationUserId {get;set;}
        public List<TasksProgress>TasksProgress{get;set;}
        public ApplicationUser ApplicationUser {get; set;}
    }
}