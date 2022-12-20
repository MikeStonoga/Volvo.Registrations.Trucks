using Hangfire;
using System.Linq.Expressions;
using Volvo.Registrations.Trucks.Adapters.BackgroundProcessing;
using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Events.Reactions;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;

namespace Volvo.Registrations.Trucks.Hangfire;

public class BackgroundProcessingService : IBackgroundProcessingService
{
    public void Enqueue(IEventReaction reaction, IDomainEvent @event)
    {
        BackgroundJob.Enqueue(React(@event));
    }

    private Expression<Action<IEventReaction>> React(IDomainEvent @event)
    {
        return reaction => reaction.Execute(@event.Id);
    }
}
