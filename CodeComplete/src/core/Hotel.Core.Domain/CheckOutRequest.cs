using Hotel.Core.Domain.Common;

namespace Hotel.Core.Domain;

public class CheckOutRequest : BaseEntity
{
    public Room? Room { get; set; }
    public int RoomId { get; set; }
}