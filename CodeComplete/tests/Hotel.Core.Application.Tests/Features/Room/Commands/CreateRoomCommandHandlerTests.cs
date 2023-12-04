using AutoMapper;
using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Application.Features.Room.Commands.CreateRoom;
using Hotel.Core.Application.MappingProfiles;
using Hotel.Core.Application.Tests.Mocks;
using Moq;
using Shouldly;

namespace Hotel.Core.Application.Tests.Features.Room.Commands;

public class CreateRoomCommandHandlerTests
{

  private readonly IMapper _mapper;
  private readonly Mock<IRoomRepository> _mockRepository;

  public CreateRoomCommandHandlerTests()
  {
    _mockRepository = MockRoomRepository.GetMockRepository();
    var mapperConfig = new MapperConfiguration(c =>
    {
      c.AddProfile<RoomProfile>();
    });

    _mapper = mapperConfig.CreateMapper();
  }

  [Fact]
  public async Task CreateRoomSuccessTest()
  {
    // arrange
    var handler = new CreateRoomCommandHandler(_mapper, _mockRepository.Object);
    var request = new CreateRoomCommand
    {
      Name = "Room 10",
      BedNumber = 2,
    };

    // act
    var result = await handler.Handle(request, CancellationToken.None);

    // assert
    result.ShouldBeOfType<int>();
    result.ShouldBeGreaterThan(0);
  }
}