namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

public interface IHaveModelId
{
    Guid ModelId { get; }
}

public interface IMayHaveModelId
{
    Guid? ModelId { get; }
    bool HasModelId => ModelId.HasValue;
}