using AutoMapper;
using Hotel.Core.Application.Features.Room.Queries.GetAvailableRooms;
using Hotel.Core.Application.Features.Room.Queries.GetRoomDetails;
using Hotel.Core.Domain;

namespace Hotel.Core.Application.MappingProfiles;

public class RoomProfile : Profile
{
  public RoomProfile()
  {
    CreateMap<RoomDto, Room>().ReverseMap();
    CreateMap<Room, RoomDetailsDto>();
  }
}