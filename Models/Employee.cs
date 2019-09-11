using System;
using System.Collections.Generic;
namespace mis.Models
{
    public class Employee
    {
        public int EmployeeId {get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string UserName {get;set;}
        public string Password {get;set;}
        public int DepartmentId {get; set;}
        public Department Department {get;set;}
    }
}