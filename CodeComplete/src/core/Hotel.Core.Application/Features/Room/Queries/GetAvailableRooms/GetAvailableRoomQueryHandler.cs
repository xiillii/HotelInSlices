using AutoMapper;
using Hotel.Core.Application.Contracts.Persistence;
using MediatR;

namespace Hotel.Core.Application.Features.Room.Queries.GetAvailableRooms;

public class GetAvailableRoomQueryHandler : IRequestHandler<GetAvailableRoomQuery, List<RoomDto>>
{
  private readonly IMapper _mapper;
  private readonly IRoomRepository _roomRepository;

  public GetAvailableRoomQueryHandler(IMapper mapper, IRoomRepository roomRepository)
  {
    this._mapper = mapper;
    this._roomRepository = roomRepository;
  }

  public async Task<List<RoomDto>> Handle(GetAvailableRoomQuery request,
                                          CancellationToken cancellationToken)
  {
    // Query the database
    var rooms = await _roomRepository.GetAsync(onlyActives: true);

    // Convert data objects to DTO objects
    var data = _mapper.Map<List<RoomDto>>(rooms);

    // return the result
    return data;
  }
}