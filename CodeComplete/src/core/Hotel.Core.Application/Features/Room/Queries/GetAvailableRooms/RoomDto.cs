namespace Hotel.Core.Application.Features.Room.Queries.GetAvailableRooms;

/// <summary>
/// Room
/// </summary>
public class RoomDto
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public int BedNumber { get; set; }
  public bool Vacant { get; set; }

}