using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Views;

public interface IViewTruckGetAllForList
    : IHaveManufacturingYear
{
    string Model { get; }
}
