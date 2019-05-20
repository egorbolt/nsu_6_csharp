using Microsoft.EntityFrameworkCore;
using Lab4Worker.UI.DB;

namespace lab4_worker_ui.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        } 
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ConnectionTable> ConnectionTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().ToTable("Workers");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<ConnectionTable>().ToTable("ConnectionTables");
        }
    }

}