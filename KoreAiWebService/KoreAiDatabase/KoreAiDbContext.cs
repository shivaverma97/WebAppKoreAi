using KoreAiDatabase.KoreAiDatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace KoreAiDatabase
{
    public class KoreAiDbContext: DbContext
    {
        public KoreAiDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("KoreAi");

            modelBuilder.Entity<CustomerInformation>().ToTable("NewCustomerInformation", "dbo");
        }

        public DbSet<CustomerInformation> CustomerInformation { get; set; }
    }
}
