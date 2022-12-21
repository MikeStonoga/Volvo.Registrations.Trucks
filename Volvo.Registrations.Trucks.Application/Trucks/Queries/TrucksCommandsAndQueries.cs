using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Trucks;
using Volvo.Registrations.Trucks.Application.Abstractions.Trucks;
using Volvo.Registrations.Trucks.Application.Abstractions.Trucks.Commands;
using Volvo.Registrations.Trucks.Application.Commons.Queries;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Views;

namespace Volvo.Registrations.Trucks.Application.Trucks.Queries;

public class TrucksCommandsAndQueries : Queries<ITruck, ITruckPersistencyGateway, IViewTruckGetAllForList>, ITrucksCommandsAndQueries
{
    private readonly IRegisterTruckCommand _registerTruck;
    private readonly IAdjustTruckCommand _adjustTruck;
    private readonly IRemoveTruckCommand _removeTruck;

    public TrucksCommandsAndQueries(
        ITruckPersistencyGateway persistencyGateway, 
        IRegisterTruckCommand registerTruck, 
        IAdjustTruckCommand adjustTruck, 
        IRemoveTruckCommand removeTruck)
        : base(persistencyGateway)
    {
        _registerTruck = registerTruck;
        _adjustTruck = adjustTruck;
        _removeTruck = removeTruck;
    }

    public async Task<IAdjustTruckResult> Adjust(IAdjustTruckRequirement requirement)
        => await _adjustTruck.Execute(requirement);

    public async Task<IRegisterTruckResult> Register(IRegisterTruckRequirement requirement)
        => await _registerTruck.Execute(requirement);

    public async Task<IRemoveTruckResult> Remove(IRemoveTruckRequirement requirement)
        => await _removeTruck.Execute(requirement);
}
