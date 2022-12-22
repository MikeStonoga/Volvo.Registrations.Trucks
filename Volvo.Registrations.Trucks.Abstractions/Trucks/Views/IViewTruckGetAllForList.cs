using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Views;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Views;

public interface IViewTruckGetAllForList
    : IView, IHaveName, IHaveManufacturingYear
{
    string Model { get; }
}
