using AutoMapper;
using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Application.Features.Room.Queries.GetRoomDetails;
using Hotel.Core.Application.MappingProfiles;
using Hotel.Core.Application.Tests.Mocks;
using Moq;
using Shouldly;

namespace Hotel.Core.Application.Tests.Features.Room.Queries;

public class GetRoomDetailsQueryHandlerTests
{
    private readonly Mock<IRoomRepository> _mockRepo;
    private readonly IMapper _mapper;

    public GetRoomDetailsQueryHandlerTests()
    {
        _mockRepo = MockRoomRepository.GetMockRepository();
        var mapperConfig = new MapperConfiguration(c => c.AddProfile<RoomProfile>());
        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetRoomDetailsTest()
    {
        // arrange
        var handler = new GetRoomDetailsQueryHandler(_mapper, _mockRepo.Object);

        // act
        var room = await handler.Handle(new GetRoomDetailsQuery(1), CancellationToken.None);

        // asserts
        room.ShouldBeOfType<RoomDetailsDto>();
        room.Name.ShouldBe("Room 1");
        room.Vacant.ShouldBeTrue();
    }

    [Fact]
    public void GetRoomDetailsNotFoundTest()
    {
        // arrange
        var handler = new GetRoomDetailsQueryHandler(_mapper, _mockRepo.Object);

        // act & assert
        Should.Throw<NotFoundException>(async () => await handler.Handle(
            new GetRoomDetailsQuery(50),
            CancellationToken.None));
    }
}