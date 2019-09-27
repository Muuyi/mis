using System;
namespace mis.Models
{
    public class TasksProgress : Base
    {
        public string Comments { get; set; }
        public string Status { get; set; }
        public string Metric { get; set; }
        public string ApplicationUserId {get;set;}
        public ApplicationUser ApplicationUser {get; set;}
        public int TasksId { get; set; }
    }
}