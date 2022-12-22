namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

public interface IMayHaveName
{
    public string? Name { get; set; }
    public bool HasName => !string.IsNullOrWhiteSpace(Name);
}