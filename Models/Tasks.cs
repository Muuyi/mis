using System;
namespace mis.Models
{
    public class Tasks : Base
    {
        public string TaskSubject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Metric { get; set; }
        public string ApplicationUserId {get;set;}
        public ApplicationUser ApplicationUser {get; set;}
    }
}