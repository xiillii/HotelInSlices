using AutoMapper;
using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Application.Exceptions;
using MediatR;

namespace Hotel.Core.Application.Features.Room.Commands.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, int>
{
  private readonly IMapper _mapper;
  private readonly IRoomRepository _roomRepository;

  public CreateRoomCommandHandler(IMapper mapper, IRoomRepository roomRepository)
  {
    this._mapper = mapper;
    this._roomRepository = roomRepository;
  }
  public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
  {
    // validate incoming data
    var validator = new CreateRoomCommandValidator(_roomRepository);
    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    if (validationResult.Errors.Any())
    {
      throw new BadRequestException("Invalid Room Data", validationResult);
    }

    // convert dto to domain entity
    var roomToCreate = _mapper.Map<Domain.Room>(request);

    // add to the database
    await _roomRepository.CreateAsync(roomToCreate);

    // return Identifier
    return roomToCreate.Id;
  }
}