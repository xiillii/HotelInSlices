using Hotel.Core.Application.Features.Room.Commands.CreateRoom;
using Hotel.Core.Application.Features.Room.Queries.GetAvailableRooms;
using Hotel.Core.Application.Features.Room.Queries.GetRoomDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
  private readonly IMediator _mediator;

  public RoomsController(IMediator mediator)
  {
    this._mediator = mediator;
  }

  [HttpGet]
  public async Task<List<RoomDto>> GetList()
  {
    var rooms = await _mediator.Send(new GetAvailableRoomQuery());

    return rooms;
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<RoomDetailsDto>> GetRoomDetails(int id)
  {
    var room = await _mediator.Send(new GetRoomDetailsQuery(id));

    return Ok(room);
  }

  [HttpPost]
  [ProducesResponseType(201)]
  [ProducesResponseType(400)]
  public async Task<ActionResult> CreateRoom(CreateRoomCommand request)
  {
    var response = await _mediator.Send(request);

    return CreatedAtAction(nameof(GetRoomDetails), new { id = response }, null);
  }
}