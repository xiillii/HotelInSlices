using Hotel.Core.Domain.Common;

namespace Hotel.Core.Domain;

public class CheckInRequest : BaseEntity {
    public string? GuestName { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }

    public Room? Room { get; set; }
    public int RoomId { get; set; }
}