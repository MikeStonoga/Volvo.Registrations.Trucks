using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities.Mappings;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities;

public abstract class BusinessModelConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class, IBusinessModel
{
    protected readonly ModelBuilder ModelBuilder;
    protected readonly string DefaultSchema;
    protected readonly string TableName;
    private readonly string _idColumnName;
    private readonly string _creationTimeColumnName;
    private readonly string _lastModificationTimeColumnName;
    private readonly string _deletionTimeColumnName;

    public BusinessModelConfiguration(
        ModelBuilder modelBuilder,
        string tableName,
        string idColumnName = DefaultColumnNames.ID,
        string creationTimeColumnName = DefaultColumnNames.CREATION_TIME,
        string lastModificationTimeColumnName = DefaultColumnNames.LAST_MODIFICATION_TIME,
        string deletionTimeColumnName = DefaultColumnNames.DELETION_TIME
    )
    {
        ModelBuilder = modelBuilder;
        _idColumnName = idColumnName;
        TableName = tableName;
        _creationTimeColumnName = creationTimeColumnName;
        _lastModificationTimeColumnName = lastModificationTimeColumnName;
        _deletionTimeColumnName = deletionTimeColumnName;
    }

    public virtual void Configure(EntityTypeBuilder<TEntity> configuration)
    {
        configuration.ToTable(TableName, DefaultSchema);
        configuration.HasKey(e => e.Id);
        configuration.Property(e => e.Id).HasColumnName(_idColumnName).IsRequired();
        configuration.Property(e => e.CreationTime).HasColumnName(DefaultColumnNames.CREATION_TIME).IsRequired();
        configuration.Property(e => e.LastModificationTime).HasColumnName(DefaultColumnNames.LAST_MODIFICATION_TIME);
        configuration.Property(e => e.DeletionTime).HasColumnName(DefaultColumnNames.DELETION_TIME);
        configuration.Property(e => e.IsDeleted).HasColumnName(DefaultColumnNames.IS_DELETED);
    }
}