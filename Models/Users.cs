namespace mis.Models
{
    public class Users : Base
    {
       public string Username { get; set; } 
       public string Password { get; set; }
       public int EmployeesId {get; set;}
    }
}