namespace mis.Models
{
    public class Administrators : Base
    {
       public string Username { get; set; } 
       public string Password { get; set; }
       public int EmployeesId {get; set;}
    }
}