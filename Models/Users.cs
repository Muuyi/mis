using System;
using System.ComponentModel.DataAnnotations;
namespace mis.Models
{
    public class Administrators : Base
    {
       public string Username { get; set; } 
       [DataType(DataType.Password)]
       public string Password { get; set; }
       public int EmployeesId {get; set;}
    }
}