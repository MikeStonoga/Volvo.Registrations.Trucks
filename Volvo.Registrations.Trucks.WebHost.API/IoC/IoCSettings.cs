using Microsoft.EntityFrameworkCore;
using Volvo.Registrations.Trucks.Application.Commons.IoC;
using Volvo.Registrations.Trucks.EfCore.SqlServer;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.IoC;

namespace Volvo.Registrations.Trucks.WebHost.API.IoC;

public static class IoCSettings
{
    public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterEfCoreSqlServerDependencies(configuration);
        services.RegisterApplicationDependencies();
        return services;
    }

    public static WebApplication ApplyMigrations(this WebApplication app)
    {

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<TrucksDbContext>();
            db.Database.Migrate();
        }

        return app;
    }
}
