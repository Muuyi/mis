using System;
namespace mis.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}