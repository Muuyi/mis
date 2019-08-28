using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace mis.Models
{
    public class AuthenticationContext : IdentityDbContext
    {
        public AuthenticationContext(DbContextOptions options): base(options)
        {
            
        }
         //USERS CONTEXT
        public DbSet<ApplicationUser>ApplicationUser{get; set;}
        //DEPARTMENTS
        public DbSet<Departments>Departments{get; set;}
        //UUSERS
         public DbSet<Administrators>Administrators{get; set;}
        //EMPLOYEES CONTEXT
        public DbSet<Employees>Employees{get; set;}
        // //CUSTOMERS CONTEXT
        public DbSet<Customers>Customers{get; set;}
        // //MEETINGS CONTEXT
        public DbSet<Meetings>Meetings{get; set;}
        // //TASKS CONTEXT
        public DbSet<Tasks>Tasks{get; set;}
        // //PROJECTS CONTEXT
        public DbSet<Projects>Projects{get; set;}
        // //TICKETS CONTEXT
        public DbSet<Tickets>Tickets{get; set;}
        // //LEAVE CONTEXT
        public DbSet<Leave>Leave{get; set;}
    }
}