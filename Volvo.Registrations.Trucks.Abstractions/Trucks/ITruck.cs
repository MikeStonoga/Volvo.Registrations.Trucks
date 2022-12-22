using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Methods;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models.Properties;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;

public interface ITruck
    : IBusinessModel,
    IHaveName,
    IHaveModelId,
    IHaveManufacturingYear,
    IHaveTruckModel,
    ICanRegister<IRegisterTruckRequirement>,
    ICanAdjust<IAdjustTruckRequirement>,
    ICanRemove<IRemoveTruckRequirement>
{
}
