using MediatR;

namespace Hotel.Core.Application.Features.Room.Queries.GetRoomDetails;

public record GetRoomDetailsQuery(int Id) : IRequest<RoomDetailsDto>;
