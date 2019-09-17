using System;
namespace mis.Models
{
    public class Tickets : Base
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}