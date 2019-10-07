using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace mis.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName="nvarchar(150)")]
        public string FullName { get; set; }
        public string ImageName { get; set; }
        public int DepartmentId {get; set;}
        public Department Department {get;set;}
    }
}