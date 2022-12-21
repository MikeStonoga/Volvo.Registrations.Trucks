using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Models;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Trucks.Models.Mappings;

public class TruckModelModelConfiguration : BusinessModelConfiguration<TruckModel>
{
    public TruckModelModelConfiguration(ModelBuilder modelBuilder) 
        : base(modelBuilder, tableName: "TruckModel")
    {
    }

    public override void Configure(EntityTypeBuilder<TruckModel> configuration)
    {
        base.Configure(configuration);
    }
}
