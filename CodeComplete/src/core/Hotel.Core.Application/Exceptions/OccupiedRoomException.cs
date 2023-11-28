namespace Hotel.Core.Application;

public class OccupiedRoomException : Exception
{
    public OccupiedRoomException(int roomId)
        : base($"Room with id {roomId} is occupied")
    {
        
    }
}