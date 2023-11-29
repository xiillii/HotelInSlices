using AutoMapper;
using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Application.Features.Room.Queries.GetAvailableRooms;
using Hotel.Core.Application.MappingProfiles;
using Hotel.Core.Application.Tests.Mocks;
using Moq;
using Shouldly;

namespace Hotel.Core.Application.Tests.Features.Room.Queries;

public class GetAvailableRoomQueryHandlerTests
{
    private readonly Mock<IRoomRepository> _mockRepo;
    private readonly IMapper _mapper;

    public GetAvailableRoomQueryHandlerTests()
    {
        _mockRepo = MockRoomRepository.GetMockRoomRepository();
        var mapperConfig = new MapperConfiguration(c => c.AddProfile<RoomProfile>());
        _mapper = mapperConfig.CreateMapper();        
    }

    [Fact]
    public async Task GetAvailableRoomsTest(){
        // arrange
        var handler = new GetAvailableRoomQueryHandler(_mapper, _mockRepo.Object);

        // act
        var result = await handler.Handle(new GetAvailableRoomQuery(), CancellationToken.None);

        // assert
        result.ShouldBeOfType<List<RoomDto>>();
        result.Count.ShouldBe(5);
    }
}