using AutoMapper;
using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Application.MappingProfiles;
using Hotel.Core.Application.Tests.Mocks;
using Moq;

namespace Hotel.Core.Application.Tests.Features.Administration.Commands;

public class CheckInCommandHandlerTests
{
  private readonly Mock<IRoomRepository> _mockRoomRepository;
  private readonly IMapper _mapper;

  public CheckInCommandHandlerTests()
  {
    _mockRoomRepository = MockRoomRepository.GetMockRepository();
    var mapperConfig = new MapperConfiguration(c =>
    {
      c.AddProfile<AdministrationProfile>();
    });

    _mapper = mapperConfig.CreateMapper();
  }
}