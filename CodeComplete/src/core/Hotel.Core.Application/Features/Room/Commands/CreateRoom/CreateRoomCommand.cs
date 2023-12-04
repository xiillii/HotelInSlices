using MediatR;

namespace Hotel.Core.Application.Features.Room.Commands.CreateRoom;

public class CreateRoomCommand : IRequest<int>
{
  public string? Name { get; set; }
  public int BedNumber { get; set; }
}