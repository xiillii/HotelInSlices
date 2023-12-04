using MediatR;

namespace Hotel.Core.Application.Features.Administration.Commands.CheckIn;

public class CheckInCommand : IRequest<Unit>
{
  public string? GuestName { get; set; }
  public int RoomId { get; set; }
  public DateTimeOffset StartDate { get; set; }
  public DateTimeOffset EndDate { get; set; }
}