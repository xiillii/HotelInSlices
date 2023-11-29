namespace Hotel.Core.Application.Features.Room.Queries.GetRoomDetails;

public class RoomDetailsDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int BedNumber { get; set; }
    public bool Vacant { get; set; }
    public DateTimeOffset? DateCreated { get; set; }
    public DateTimeOffset? DateModified { get; set; }
}