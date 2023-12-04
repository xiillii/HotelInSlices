using FluentValidation;
using Hotel.Core.Application.Contracts.Persistence;

namespace Hotel.Core.Application.Features.Room.Commands.CreateRoom;

class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
{
  private readonly IRoomRepository _roomRepository;

  public CreateRoomCommandValidator(IRoomRepository roomRepository)
  {
    this._roomRepository = roomRepository;

    RuleFor(r => r.Name).NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .MaximumLength(70)
            .WithMessage("{PropertyName} must be fewer than 70 characters");
    RuleFor(r => r.BedNumber).NotNull()
            .GreaterThan(0)
            .WithMessage("{PropertyName} must be grather than 0")
            .LessThan(10)
            .WithMessage("{PropertyName} must be less than 10");
    RuleFor(r => r).MustAsync(RoomNameUnique)
            .WithMessage("Room name alread exists");
  }

  private async Task<bool> RoomNameUnique(CreateRoomCommand command, CancellationToken cancellationToken)
  {
    return await _roomRepository.IsRoomUnique(command.Name);
  }
}