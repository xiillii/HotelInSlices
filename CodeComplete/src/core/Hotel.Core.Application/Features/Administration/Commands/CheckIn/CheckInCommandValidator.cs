using FluentValidation;
using Hotel.Core.Application.Contracts.Persistence;

namespace Hotel.Core.Application.Features.Administration.Commands.CheckIn;

public class CheckInCommandValidator : AbstractValidator<CheckInCommand>
{
  private readonly IRoomRepository _roomRepository;

  public CheckInCommandValidator(IRoomRepository roomRepository)
  {
    _roomRepository = roomRepository;

    RuleFor(c => c.GuestName).NotEmpty()
                             .WithMessage("{PropertyName} is required")
                             .MaximumLength(70)
                             .WithMessage("{PropertyName} must be fewer than 70 characters");

    RuleFor(c => c).Must(ValidStartEndDates)
            .WithMessage("Start Date must be less or equal to End Date");

    RuleFor(c => c).MustAsync(RoomMustExistsAsync)
            .WithMessage("Room must exists");

    RuleFor(c => c).MustAsync(RoomMustBeAvailableAsync)
    .WithMessage("Room must be available");
  }

  private bool ValidStartEndDates(CheckInCommand command)
  {
    return command.StartDate <= command.EndDate;
  }

  private async Task<bool> RoomMustExistsAsync(CheckInCommand command, CancellationToken cancellationToken)
  {
    return await _roomRepository.GetByIdAsync(command.RoomId) != null;
  }

  private async Task<bool> RoomMustBeAvailableAsync(CheckInCommand command, CancellationToken cancellationToken)
  {
    var room = await _roomRepository.GetByIdAsync(command.RoomId);

    return room?.Vacant ?? false;
  }
}