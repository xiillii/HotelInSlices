using MediatR;

namespace Hotel.Core.Application.Features.Room.Queries.GetAvailableRooms;

// public class GetAvailableRoomQuery : IRequest<List<RoomDto>>
// {
    
// }

/// <summary>
/// Query the available rooms
/// </summary>
/// <see cref="https://medium.com/net-tips/record-vs-class-in-c-ac675f841028"/>
public record GetAvailableRoomQuery : IRequest<List<RoomDto>>;