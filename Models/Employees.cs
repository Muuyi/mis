using System;
namespace mis.Models
{
    public class Employees : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string UserName {get;set;}
        public string Password {get;set;}
        public int DepartmentId { get; set; }
    }
}