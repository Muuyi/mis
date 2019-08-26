using Microsoft.EntityFrameworkCore;

namespace mis.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base (options){

        }
        //DEPARTMENTS CONTEXT
        public DbSet<Departments>Departments{get; set;}
        //EMPLOYEES CONTEXT
        public DbSet<Employees>Employees{get; set;}
        //USERS CONTEXT
        public DbSet<Users>Users{get; set;}
        //CUSTOMERS CONTEXT
        public DbSet<Customers>Customers{get; set;}
        //MEETINGS CONTEXT
        public DbSet<Meetings>Meetings{get; set;}
        //TASKS CONTEXT
        public DbSet<Tasks>Tasks{get; set;}
        //PROJECTS CONTEXT
        public DbSet<Projects>Projects{get; set;}
        //TICKETS CONTEXT
        public DbSet<Tickets>Tickets{get; set;}
        //LEAVE CONTEXT
        public DbSet<Leave>Leave{get; set;}
    }
}