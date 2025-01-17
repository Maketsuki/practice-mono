using MicroserviceTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MicroserviceTemplate.Data
{
    public class MicroserviceTemplateDbContext : DbContext
    {
        public DbSet<ThingEntity> Thing { get; set; } = default!;

        public MicroserviceTemplateDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            foreach (EntityEntry entity in ChangeTracker.Entries().Where(x => x.Entity is StampEntity && (x.State == EntityState.Added || x.State == EntityState.Modified)))
            {
                if (entity.State == EntityState.Added)
                {
                    ((StampEntity)entity.Entity).DateCreated = DateTime.UtcNow;
                }

                ((StampEntity)entity.Entity).DateModified = DateTime.UtcNow;
            }
        }
    }
}