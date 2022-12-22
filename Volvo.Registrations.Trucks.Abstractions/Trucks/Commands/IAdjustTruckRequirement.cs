using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Properties;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;

public interface IAdjustTruckRequirement
    : IHaveTruckId,
    IMayHaveManufacturingYear,
    IMayHaveModelId,
    IMayHaveName
{
}
