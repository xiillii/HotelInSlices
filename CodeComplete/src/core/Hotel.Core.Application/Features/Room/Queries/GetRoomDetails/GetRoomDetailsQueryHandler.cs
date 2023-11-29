using AutoMapper;
using Hotel.Core.Application.Contracts.Persistence;
using MediatR;

namespace Hotel.Core.Application.Features.Room.Queries.GetRoomDetails;

public class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IRoomRepository _roomRepository;

    public GetRoomDetailsQueryHandler(IMapper mapper, IRoomRepository roomRepository)
    {
        this._mapper = mapper;
        this._roomRepository = roomRepository;
    }

    public async Task<RoomDetailsDto> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
    {
        // query database
        var room = await _roomRepository.GetByIdAsync(request.Id)
                   ?? throw new NotFoundException(nameof(Domain.Room), request.Id);

        // convert data object to DTO object
        var data = _mapper.Map<RoomDetailsDto>(room);

        // return the result
        return data;
    }
}