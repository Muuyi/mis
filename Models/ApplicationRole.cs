using Microsoft.AspNetCore.Identity;
using System;
namespace mis.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() {  }
        public ApplicationRole(string roleName) : base(roleName)
        {
            
        }
        public ApplicationRole(string roleName, string description, DateTime creationDate) : base(roleName)
        {
            this.Description = description;
            this.CreationDate = creationDate;
        }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        // public const string Admin = "Admin";
        // public const string User = "User";
    }
}