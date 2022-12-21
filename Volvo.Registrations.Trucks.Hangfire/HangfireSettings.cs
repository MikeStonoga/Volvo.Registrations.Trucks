using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volvo.Registrations.Trucks.Adapters.BackgroundProcessing;
using Volvo.Registrations.Trucks.Hangfire;

namespace Volvo.Registrations.Trucks.Hangfire;

public static class HangfireSettings
{

    public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration Configuration)
    {
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"))
        );

        // Add the processing server as IHostedService
        services.AddHangfireServer();
        services.AddScoped<IBackgroundProcessingService, BackgroundProcessingService>();

        return services;
    }

    public static IApplicationBuilder UseHangfire(this IApplicationBuilder app, IBackgroundJobClient backgroundJobs)
    {
        app.UseHangfireDashboard();
        backgroundJobs.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
        return app;
    }
}
