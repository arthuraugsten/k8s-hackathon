using Microsoft.EntityFrameworkCore;

namespace KubernetesHackathon.Core;

public sealed class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }

    public DbSet<Vote> Votes => Set<Vote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vote>(entity =>
        {
            entity.ToTable("Votes");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.CreatedAt).IsRequired();
        });
    }
}
