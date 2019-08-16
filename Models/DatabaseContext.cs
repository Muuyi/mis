using Microsoft.EntityFrameworkCore;

namespace mis.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base (options){

        }
        public DbSet<Departments>Departments{get; set;}
    }
}