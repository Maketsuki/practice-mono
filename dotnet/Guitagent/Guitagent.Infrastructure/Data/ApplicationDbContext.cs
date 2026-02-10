using Microsoft.EntityFrameworkCore;
using Guitagent.Domain.Entities;

namespace Guitagent.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<RoutineExercise>()
            .HasKey(re => re.Id);
            
        modelBuilder.Entity<Routine>()
            .HasOne(r => r.User)
            .WithMany(u => u.Routines)
            .HasForeignKey(r => r.UserId);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Routine> Routines { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<RoutineExercise> RoutineExercises { get; set; }
}
