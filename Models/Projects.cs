using System;
using System.Collections.Generic;
namespace mis.Models
{
    public class Projects : Base
    {
        public string ProjectName { get; set; }
        public string Metric { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<ProjectsProgress> ProjectsProgress{get;set;}
    }
}