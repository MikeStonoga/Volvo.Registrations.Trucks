using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Trucks;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities.Mappings;
using Volvo.Registrations.Trucks.BusinessModels.Commons.Events;
using Microsoft.Extensions.Configuration;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Events.Mappings;

public class DomainEventModelConfiguration : BusinessModelConfiguration<DomainEvent>
{
    private string SerializedContentColumnName => "serialized_content";
    public DomainEventModelConfiguration(ModelBuilder modelBuilder)
        : base(modelBuilder, tableName: "DomainEvent")
    {
    }

    public override void Configure(EntityTypeBuilder<DomainEvent> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Name).HasColumnName(DefaultColumnNames.NAME).IsRequired() ;
        builder.Property(e => e.SerializedContent).HasColumnName(SerializedContentColumnName).IsRequired();
        builder.Ignore(e => e.LastModificationTime);
        builder.Ignore(e => e.DeletionTime);
        builder.Ignore(e => e.IsDeleted);
    }
}
