namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

public interface IHaveManufacturingYear
{
    int ManufacturingYear { get; } 
}

public interface IMayHaveManufacturingYear
{
    int? ManufacturingYear { get; }
    bool HasManufacturingYear => ManufacturingYear.HasValue;
}