namespace mis.Models
{
    public class LeaveHolder : Base
    {
       public int LeaveId { get; set; } 
       public string ApplicationUserId { get; set; }
       public Leave Leave { get; set; }
       public ApplicationUser ApplicationUser { get; set; }
    }
}