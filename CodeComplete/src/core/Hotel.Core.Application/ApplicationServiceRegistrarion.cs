using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Core.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(assembly);
        services.AddMediatR(conf => conf.RegisterServicesFromAssemblies(assembly));        

        return services;
    }
}
