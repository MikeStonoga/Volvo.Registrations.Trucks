using MediatR;
using Microsoft.Extensions.Logging;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Trucks;
using Volvo.Registrations.Trucks.Application.Abstractions.Trucks.Commands;
using Volvo.Registrations.Trucks.Application.Commons.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events.Extensions;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Events.Removeds;

namespace Volvo.Registrations.Trucks.Application.Trucks.Commands;

public class RemoveTruckCommand : Command<RemoveTruckCommand, IRemoveTruckRequirement, IRemoveTruckResult, ITruck, ITruckPersistencyGateway>, IRemoveTruckCommand
{
    public RemoveTruckCommand(
        IUnitOfWork unitOfWork,
        ILogger<RemoveTruckCommand> logger, 
        IMediator mediator, 
        IDomainEventsPersistencyGateway domainEvents, 
        ITruckPersistencyGateway dataAccessGateway
    ) : base(unitOfWork, logger, mediator, domainEvents, dataAccessGateway)
    {
    }

    protected override async Task<ManipulateBusinessModelsDTO.Result> ManipulateBusinessModels(IRemoveTruckRequirement requirement)
    {
        var truck = await DataPersistencyGateway.GetById(requirement.TruckId);
        
        bool truckWasFound = truck != null;
        if (!truckWasFound)
            throw new Exception("Truck was not found to remove!");

        truck.MarkAsDeleted();

        return new(truck);
    }

    protected override List<IDomainEvent> PrepareEventsForPublishing(PrepareEventsForPublishingDTO.Requirement requirement)
        => new List<IDomainEvent>(capacity: 1)
        {
            new TruckRemoved(requirement.BusinessModelManipulationResult.Id).ToDomainEvent($"({nameof(Truck)}: {requirement.BusinessModelManipulationResult.Id}")
        };

    protected override async Task SaveChanges(ManipulateBusinessModelsDTO.Result requirement)
        => await DataPersistencyGateway.SoftDelete(requirement.BusinessModelManipulationResult);

    protected override async Task<IRemoveTruckResult> FormatResult(FormatResultDTO.Requirement requirement)
    {
        return new RemoveTruckDTO.Result();
    }
}
