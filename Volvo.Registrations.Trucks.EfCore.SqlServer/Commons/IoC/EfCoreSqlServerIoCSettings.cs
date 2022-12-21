using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Trucks;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Events.Repositories;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Trucks.Repositories;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.IoC;

public static class EfCoreSqlServerIoCSettings
{
    public static IServiceCollection RegisterEfCoreSqlServerDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<TrucksDbContext>(options =>
                   options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDomainEventsPersistencyGateway, DomainEventRepository>();

        services.RegisterTrucksEfCoreSqlServerDependencies();
        return services;
    }

    private static IServiceCollection RegisterTrucksEfCoreSqlServerDependencies(this IServiceCollection services)
    {
        services.AddScoped<ITruckPersistencyGateway, TruckRepository>();
        return services;
    }
}
