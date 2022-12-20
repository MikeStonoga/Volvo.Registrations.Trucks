namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

public interface IHaveSoftDelete
{
    DateTime? DeletionTime { get; }
    bool IsDeleted { get; }
    void MarkAsDeleted();
}
