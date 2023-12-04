using AutoMapper;
using Hotel.Core.Application.Features.Administration.Commands.CheckIn;
using Hotel.Core.Domain;

namespace Hotel.Core.Application.MappingProfiles;

public class AdministrationProfile : Profile
{
  public AdministrationProfile()
  {
    CreateMap<CheckInCommand, CheckInRequest>();
  }
}