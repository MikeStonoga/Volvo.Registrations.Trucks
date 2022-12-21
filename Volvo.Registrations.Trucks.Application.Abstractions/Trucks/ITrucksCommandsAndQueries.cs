using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Queries;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Views;

namespace Volvo.Registrations.Trucks.Application.Abstractions.Trucks;

public interface ITrucksCommandsAndQueries : IQueries<ITruck>
{
    Task<IRegisterTruckResult> Register(IRegisterTruckRequirement requirement);
    Task<IAdjustTruckResult> Adjust(IAdjustTruckRequirement requirement);
    Task<IRemoveTruckResult> Remove(IRemoveTruckRequirement requirement);
}
