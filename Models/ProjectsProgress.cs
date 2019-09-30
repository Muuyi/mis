using System;
namespace mis.Models
{
    public class ProjectsProgress : Base
    {
        public string Comments { get; set; }
        public string Metric { get; set; }
        public int ProjectsId { get; set; }
        public string ApplicationUserId {get;set;}
        public ApplicationUser ApplicationUser {get; set;}
    }
}