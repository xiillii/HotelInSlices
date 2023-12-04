using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Domain;
using Hotel.Infrastructure.Persistence.DatabaseContext;

namespace Hotel.Infrastructure.Persistence.Repositories;

public class CheckInRepositoryImpl : GenericRepositoryImpl<CheckInRequest>, ICheckInRepository
{
  public CheckInRepositoryImpl(EFDatabaseContext context) : base(context)
  {
  }
}