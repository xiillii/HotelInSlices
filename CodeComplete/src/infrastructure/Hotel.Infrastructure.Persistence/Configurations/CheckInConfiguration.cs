using Hotel.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Persistence.Configurations;

public class CheckInConfiguration : IEntityTypeConfiguration<CheckInRequest>
{
  public void Configure(EntityTypeBuilder<CheckInRequest> builder)
  {
    builder.HasData(new[]{
      new CheckInRequest
      {
        Id = 1,
        GuestName = "Gest 1",
        RoomId = 2,
        StartDate = DateTimeOffset.Now,
        EndDate = DateTimeOffset.Now.AddDays(3),
        DateCreated = DateTimeOffset.Now,
        DateModified = DateTimeOffset.Now,
      },
      });
  }
}