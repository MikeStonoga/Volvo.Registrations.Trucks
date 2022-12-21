using Microsoft.Extensions.DependencyInjection;
using Volvo.Registrations.Trucks.Application.Abstractions.Trucks;
using Volvo.Registrations.Trucks.Application.Abstractions.Trucks.Commands;
using Volvo.Registrations.Trucks.Application.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.Application.Trucks.Commands;
using Volvo.Registrations.Trucks.Application.Trucks.Models;
using Volvo.Registrations.Trucks.Application.Trucks.Queries;

namespace Volvo.Registrations.Trucks.Application.Commons.IoC;

public static class ApplicationIoCSettings
{
    public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
    {
        services.RegisterTrucksDepedencies();
        services.RegisterTrucksModelsDependencies();
        return services;
    }

    private static IServiceCollection RegisterTrucksDepedencies(this IServiceCollection services)
    {
        services.AddTransient<IRegisterTruckCommand, RegisterTruckCommand>();
        services.AddTransient<IAdjustTruckCommand, AdjustTruckCommand>();
        services.AddTransient<IRemoveTruckCommand, RemoveTruckCommand>();
        services.AddTransient<ITrucksCommandsAndQueries, TrucksCommandsAndQueries>();

        return services;
    }

    public static IServiceCollection RegisterTrucksModelsDependencies(this IServiceCollection services)
    {
        services.AddTransient<ITruckModelQueriesAndCommands, TruckModelQueriesAndCommands>();
        
        return services;
    }
}
