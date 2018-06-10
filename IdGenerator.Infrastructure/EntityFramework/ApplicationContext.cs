using IdGenerator.Core;
using Microsoft.EntityFrameworkCore;

namespace IdGenerator.Infrastructure.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<FactoryParts> UniquePartsIdS { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(t => t.Id);
            modelBuilder.Entity<Factory>().HasKey(t => t.Id);

            modelBuilder.Entity<FactoryParts>()
            .HasKey(ok => new { ok.CategoryId, ok.FactoryId, ok.CategoryFactoryId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
