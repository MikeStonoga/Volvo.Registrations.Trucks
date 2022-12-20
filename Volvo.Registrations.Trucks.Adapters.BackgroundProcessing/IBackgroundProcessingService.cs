using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Events.Reactions;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;

namespace Volvo.Registrations.Trucks.Adapters.BackgroundProcessing;

public interface IBackgroundProcessingService
{
    void Enqueue(IEventReaction reaction, IDomainEvent @event);
}
