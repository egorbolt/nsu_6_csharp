using Microsoft.EntityFrameworkCore;

namespace lab4_worker {
    public class ApplicationContext : DbContext {
        public DbSet<Worker> Workers { get; set; }

        public ApplicationContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=lab4db;Trusted_Connection=True;");
        }
    }
}