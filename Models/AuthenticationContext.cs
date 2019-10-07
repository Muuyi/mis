using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace mis.Models
{
    public class AuthenticationContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public AuthenticationContext(DbContextOptions options): base(options)
        {
            
        }
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        //     // modelBuilder.Entity<Meetings>().HasMany(s => s.MeetingsProgressHistory).WithOne(s => s.Meetings);
        //     modelBuilder.Entity<Tasks>().HasMany(s => s.TasksProgress).WithOne(s => s.Tasks);
        // }
         //USERS CONTEXT
        public DbSet<ApplicationUser>ApplicationUser{get; set;}
        //DEPARTMENTS
        public DbSet<Department>Departments{get; set;}
        //UUSERS
         public DbSet<Administrators>Administrators{get; set;}
        //EMPLOYEES CONTEXT
        public DbSet<Employee>Employees{get; set;}
        // //CUSTOMERS CONTEXT
        public DbSet<Customers>Customers{get; set;}
        // //MEETINGS CONTEXT
        public DbSet<Meetings>Meetings{get; set;}
        // //TASKS CONTEXT
        public DbSet<Tasks>Tasks{get; set;}
        // TASKS PROGRESS
        public DbSet<TasksProgress>TasksProgress{get; set;}
        // //PROJECTS CONTEXT
        public DbSet<Projects>Projects{get; set;}
        //PROJECTS PROGRESS
        public DbSet<ProjectsProgress>ProjectsProgress{get; set;}
        // //TICKETS CONTEXT
        public DbSet<Tickets>Tickets{get; set;}
        // TICKETS PROGRESS
        public DbSet<TicketsProgress>TicketsProgress{get; set;}
        // //LEAVE CONTEXT
        public DbSet<Leave>Leave{get; set;}
        public DbSet<LeaveHolder>LeaveHolder{get;set;}
        // Meetings ATTENDANCE
        public DbSet<MeetingAttendance>MeetingAttendance{get;set;}
        public DbSet<MeetingProgress>MeetingProgress{get;set;}
        public DbSet<MeetingsProgressHistory>MeetingsProgressHistory{get;set;}
    }
}