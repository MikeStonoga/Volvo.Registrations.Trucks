namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities.Properties;

public interface IHaveLastModificationInfo
{
    DateTime? LastModificationTime { get; }
    bool WasModified => LastModificationTime.HasValue;
    void MarkAsModified();
}
