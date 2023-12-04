using Hotel.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Infrastructure.Persistence.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
  public void Configure(EntityTypeBuilder<Room> builder)
  {
    builder.HasData(new[]{
      new Room
      {
        Id = 1,
        Name = "Room 1",
        BedNumber = 1,
        Vacant = true,
        DateCreated = DateTimeOffset.Now,
        DateModified = DateTimeOffset.Now,
      },
      new Room
      {
        Id = 2,
        Name = "Room 2",
        BedNumber = 1,
        Vacant = false,
        DateCreated = DateTimeOffset.Now,
        DateModified = DateTimeOffset.Now,
      },
      new Room
      {
        Id = 3,
        Name = "Room 3",
        BedNumber = 1,
        Vacant = true,
        DateCreated = DateTimeOffset.Now,
        DateModified = DateTimeOffset.Now,
      },
      new Room
      {
        Id = 4,
        Name = "Room 4",
        BedNumber = 1,
        Vacant = true,
        DateCreated = DateTimeOffset.Now,
        DateModified = DateTimeOffset.Now,
      },
      new Room
      {
        Id = 5,
        Name = "Room 5",
        BedNumber = 1,
        Vacant = true,
        DateCreated = DateTimeOffset.Now,
        DateModified = DateTimeOffset.Now,
      },
      new Room
      {
        Id = 6,
        Name = "Room 6",
        BedNumber = 1,
        Vacant = true,
        DateCreated = DateTimeOffset.Now,
        DateModified = DateTimeOffset.Now,
      },
      });

    builder.Property(r => r.Name).IsRequired().HasMaxLength(70);
  }
}