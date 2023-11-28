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
        Vacant = true,
      },
      new Room{
        Id = 3,
        Name = "Room 3",
        BedNumber = 6,
        Vacant = true,
      },
    };

    var mockRepo = new Mock<IRoomRepository>();

    mockRepo.Setup(r => r.GetAsync(true)).ReturnsAsync(rooms.Where(r => r.Vacant).ToList());

    return mockRepo;
  }
}