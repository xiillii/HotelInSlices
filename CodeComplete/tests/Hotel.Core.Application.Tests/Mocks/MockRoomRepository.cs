using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Domain;
using Moq;

namespace Hotel.Core.Application.Tests.Mocks;

public class MockRoomRepository
{
  public static Mock<IRoomRepository> GetMockRoomRepository()
  {
    var rooms = new List<Room>
    {
      new Room{
        Id = 1,
        Name = "Room 1",
        BedNumber = 3,
        Vacant = true,
      },
      new Room{
        Id = 2,
        Name = "Room 2",
        BedNumber = 1,
        Vacant = false,
      },
      new Room{
        Id = 3,
        Name = "Room 3",
        BedNumber = 6,
        Vacant = true,
      },
      new Room{
        Id = 4,
        Name = "Room 4",
        BedNumber = 6,
        Vacant = true,
      },
      new Room{
        Id = 5,
        Name = "Room 5",
        BedNumber = 1,
        Vacant = true,
      },
      new Room{
        Id = 6,
        Name = "Room 6",
        BedNumber = 1,
        Vacant = true,
      },
    };

    var mockRepo = new Mock<IRoomRepository>();

    //mockRepo.Setup(r => r.GetAsync(true)).ReturnsAsync(rooms.Where(r => r.Vacant).ToList());
    //mockRepo.Setup(r => r.GetAsync(false)).ReturnsAsync(rooms);
    mockRepo.Setup(r => r.GetAsync(It.IsAny<bool>())).Returns(async (bool onlyActive) =>
    {
      if (onlyActive){
        return await Task.FromResult(rooms.Where(r => r.Vacant).ToList());
      }
      return await Task.FromResult(rooms);
    }); 
    mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).Returns((int id) =>
    {
        return Task.FromResult(rooms.Find(r => r.Id == id));
    });

    return mockRepo;
  }
}