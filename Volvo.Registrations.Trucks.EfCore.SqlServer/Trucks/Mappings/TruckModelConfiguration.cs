using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volvo.Registrations.Trucks.BusinessModels.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Models;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Trucks.Mappings;

public class TruckModelConfiguration : BusinessModelConfiguration<Truck>
{
    public TruckModelConfiguration(ModelBuilder modelBuilder) 
        : base(modelBuilder, tableName: "Truck")
    {
    }

    public override void Configure(EntityTypeBuilder<Truck> configuration)
    {
        base.Configure(configuration);

        configuration.Property(e => e.ModelId)
            .HasColumnName("model_id")
            .IsRequired();

        configuration
            .HasOne(e => (TruckModel)e.TruckModel)
            .WithOne()
            .HasForeignKey<Truck>(e => e.ModelId);

        configuration.Property(e => e.ManufacturingYear)
            .HasColumnName("manufacturing_year")
            .IsRequired();
    }
}
