using Volvo.Registrations.Trucks.Adapters.BackgroundProcessing;
using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Events.Handlers;
using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Events.Reactions;
using Volvo.Registrations.Trucks.BusinessModels.Commons.Events;

namespace Volvo.Registrations.Trucks.Application.Commons.Events.Handlers;

public class EventHandler<TEventHandler, TEvent> : IEventHandler<DomainEvent<TEvent>>
{
    private readonly IBackgroundProcessingService _backgroundProcessingService;
    private readonly IEventReaction[] _reactions;

    public EventHandler(
        IBackgroundProcessingService backgroundProcessingService,
        params IEventReaction[] reactions
    )
    {
        _backgroundProcessingService = backgroundProcessingService;
        _reactions = reactions;
    }

    public async Task Handle(DomainEvent<TEvent> @event, CancellationToken cancellationToken)
    {
        foreach (var reaction in _reactions)
            _backgroundProcessingService.Enqueue(reaction, @event);
    }
}
