using System;
namespace mis.Models
{
    public class Projects : Base
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee {get; set;}
    }
}