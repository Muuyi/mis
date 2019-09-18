namespace mis.Models
{
    public class LeaveHolder : Base
    {
       public int LeaveId { get; set; } 
       public int EmployeeId { get; set; }
       public Leave Leave { get; set; }
       public Employee Employee { get; set; }
    }
}