using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Domain;
using Hotel.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infrastructure.Persistence.Repositories;

public class RoomRepositoryImpl : GenericRepositoryImpl<Room>, IRoomRepository
{
  public RoomRepositoryImpl(EFDatabaseContext context) : base(context)
  {
  }

  public override async Task<IReadOnlyList<Room>> GetAsync(bool onlyActives = false)
  {
    if (onlyActives)
    {
      return await _context.Set<Room>()
                .AsNoTracking()
                .Where(r => r.Vacant)
                .ToListAsync();
    }
    return await base.GetAsync(false);
  }
  public async Task<bool> IsRoomUnique(string name)
  {
    var notUnique = await _context.Rooms
                                  .AnyAsync(r => r.Name! == name);

    return !notUnique;
  }

  public override Task CreateAsync(Room entity)
  {
    entity.Vacant = true;
    return base.CreateAsync(entity);
  }
}