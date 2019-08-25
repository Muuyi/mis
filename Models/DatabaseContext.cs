using Microsoft.EntityFrameworkCore;

namespace mis.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base (options){

        }
        public DbSet<Departments>Departments{get; set;}
        public DbSet<Employees>Employees{get; set;}
         public DbSet<Users>Users{get; set;}
         public DbSet<Customers>Customers{get; set;}
         public DbSet<Meetings>Meetings{get; set;}
    }
}