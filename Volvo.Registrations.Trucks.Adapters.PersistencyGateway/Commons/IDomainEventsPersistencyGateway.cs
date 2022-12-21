using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;

namespace Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;

public interface IDomainEventsPersistencyGateway : IPersistencyGateway<IDomainEvent>
{
}
