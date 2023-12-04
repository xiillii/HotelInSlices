using Hotel.Core.Domain;
using Hotel.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence.DatabaseContext;

public class EFDatabaseContext : DbContext
{
  public DbSet<Room> Rooms { get; set; }
  public DbSet<CheckInRequest> CheckIns { get; set; }
  public DbSet<CheckOutRequest> CheckOuts { get; set; }

  public EFDatabaseContext(DbContextOptions<EFDatabaseContext> options)
    : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDatabaseContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
        .Where(e => e.State is EntityState.Added or EntityState.Modified))
    {
      entry.Entity.DateModified = DateTime.UtcNow;

      if (entry.State is EntityState.Added)
      {
        entry.Entity.DateCreated = DateTime.UtcNow;
      }
    }

    return base.SaveChangesAsync(cancellationToken);
  }
}