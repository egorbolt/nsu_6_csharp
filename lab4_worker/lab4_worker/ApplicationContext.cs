using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace lab4
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=12345;database=usersdb6;");
        }
    }
}