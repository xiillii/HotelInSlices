using Hotel.Core.Application.Contracts.Persistence;
using Hotel.Infrastructure.Persistence.DatabaseContext;
using Hotel.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Infrastructure.Persistence;

public static class PersistanceServiceRegistration
{
  public static IServiceCollection AddPersistanceServices(this IServiceCollection services,
                                                          IConfiguration configuration)
  {

    services.AddDbContext<EFDatabaseContext>(options =>
    {
      options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
    });

    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepositoryImpl<>));
    services.AddScoped<IRoomRepository, RoomRepositoryImpl>();
    services.AddScoped<ICheckInRepository, CheckInRepositoryImpl>();
    services.AddScoped<ICheckOutRepository, CheckOutRepositoryImpl>();

    return services;
  }
}