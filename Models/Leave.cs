using System;
namespace mis.Models
{
    public class Leave : Base
    {
        public int EmployeesId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PlaceholderId { get; set; }
    }
}