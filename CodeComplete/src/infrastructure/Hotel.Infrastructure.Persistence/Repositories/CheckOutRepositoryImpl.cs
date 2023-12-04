using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Core.Domain;
using Hotel.Infrastructure.Persistence.DatabaseContext;

namespace Hotel.Infrastructure.Persistence.Repositories;

class CheckOutRepositoryImpl : GenericRepositoryImpl<CheckOutRequest>, ICheckOutRepository
{
  public CheckOutRepositoryImpl(EFDatabaseContext context) : base(context)
  {
  }
}