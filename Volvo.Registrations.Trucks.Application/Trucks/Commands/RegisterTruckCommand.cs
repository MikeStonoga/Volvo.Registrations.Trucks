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
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Events;

namespace Volvo.Registrations.Trucks.Application.Trucks.Commands;

public class RegisterTruckCommand : Command<RegisterTruckCommand, IRegisterTruckRequirement, IRegisterTruckResult, ITruck, ITruckPersistencyGateway>, IRegisterTruckCommand
{
    public RegisterTruckCommand(
        IUnitOfWork unitOfWork, 
        ILogger<RegisterTruckCommand> logger,
        IMediator mediator, 
        IDomainEventsPersistencyGateway domainEvents, 
        ITruckPersistencyGateway dataAccessGateway
    ) : base(unitOfWork, logger, mediator, domainEvents, dataAccessGateway)
    {
    }

    protected override async Task<ManipulateBusinessModelsDTO.Result> ManipulateBusinessModels(IRegisterTruckRequirement requirement)
    {
        var truck = Truck.Register(requirement);
        return new(truck);
    }

    protected override List<IDomainEvent> PrepareEventsForPublishing(PrepareEventsForPublishingDTO.Requisito requirement)
        => new List<IDomainEvent>(capacity: 1)
        {
            new TruckRegistered(truck: requirement.BusinessModelManipulationResult).ToDomainEvent($"({nameof(Truck)}: {requirement.BusinessModelManipulationResult.Id})")
        };

    protected override async Task SaveChanges(ManipulateBusinessModelsDTO.Result requirement)
        => await DataPersistencyGateway.Insert(requirement.BusinessModelManipulationResult);

    protected override async Task<IRegisterTruckResult> FormatResult(FormatResultDTO.Requirement requirement)
    {
        return new RegisterTruckDTO.Result(truck: requirement.BusinessModelManipulationResult);
    }
}
