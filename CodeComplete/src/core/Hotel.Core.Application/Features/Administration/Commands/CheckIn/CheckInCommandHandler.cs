using AutoMapper;
using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Application.Exceptions;
using MediatR;

namespace Hotel.Core.Application.Features.Administration.Commands.CheckIn;

public class CheckInCommandHandler : IRequestHandler<CheckInCommand, Unit>
{
  private readonly IMapper _mapper;
  private readonly ICheckInRepository _checkInRepository;
  private readonly IRoomRepository _roomRepository;

  public CheckInCommandHandler(IMapper mapper, ICheckInRepository checkInRepository, IRoomRepository roomRepository)
  {
    _mapper = mapper;
    _checkInRepository = checkInRepository;
    _roomRepository = roomRepository;
  }

  public async Task<Unit> Handle(CheckInCommand request, CancellationToken cancellationToken)
  {
    // validate the data
    var validator = new CheckInCommandValidator(_roomRepository);
    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    if (validationResult.Errors.Any())
    {
      throw new BadRequestException("Invalid Check In Data", validationResult);
    }

    // whe have to update the Room field Vacant
    var room = await _roomRepository.GetByIdAsync(request.RoomId);
    room!.Vacant = false;

    // Convert the DTO to domain entity
    var checkIn = _mapper.Map<Domain.CheckInRequest>(request);


    // Insert the data to the database

    // If you make a transacction between the repositories, do it in the implementation
    await _checkInRepository.CreateAsync(checkIn);
    await _roomRepository.UpdateAsync(room);

    // Returns nothing
    return Unit.Value;
  }
}