namespace Hotel.Core.Application;

public class VacantRoomException : Exception
{
    public VacantRoomException(int roomId)
        : base($"Room with id {roomId} is vacant")
    {
        
    }
}