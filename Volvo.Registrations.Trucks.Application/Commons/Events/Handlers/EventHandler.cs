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
        params IEventReaction[] reaction
    )
    {
        _backgroundProcessingService = backgroundProcessingService;
        _reactions = reaction;
    }

    public async Task Handle(DomainEvent<TEvent> @event, CancellationToken cancellationToken)
    {
        foreach (var reaction in _reactions)
            _backgroundProcessingService.Enqueue(reaction, @event);
    }
}
