using System;
namespace mis.Models
{
    public class Leave : Base
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PlaceholderId { get; set; }
        public Employee Employee {get; set;}
    }
}