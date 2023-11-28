using Hotel.Core.Domain.Common;

namespace Hotel.Core.Domain;

public class Room : BaseEntity {
    public string? Name { get; set; }
    public int BedNumber { get; set; }
    public bool Vacant { get; set; }
}

