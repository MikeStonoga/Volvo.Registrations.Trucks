using Microsoft.EntityFrameworkCore;
using Volvo.Registrations.Trucks.BusinessModels.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Models;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Events.Mappings;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Trucks.Mappings;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Trucks.Models.Mappings;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer;

public class TrucksDbContext : DbContext
{
    public DbSet<TruckModel> TrucksModels { get; set; }
    public DbSet<Truck> Trucks { get; set; }

    public TrucksDbContext(DbContextOptions<TrucksDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DomainEventModelConfiguration(modelBuilder));
        modelBuilder.ApplyConfiguration(new TruckModelModelConfiguration(modelBuilder));
        modelBuilder.ApplyConfiguration(new TruckModelConfiguration(modelBuilder));
    }
}