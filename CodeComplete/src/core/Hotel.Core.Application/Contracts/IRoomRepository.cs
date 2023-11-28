using Hotel.Core.Domain;

namespace Hotel.Core.Application.Contracts.Persistence;

public interface IRoomRepository : IGenericRepository<Room>
{
    Task<bool> IsRoomUnique(string name);
}