using MediatR;
using Microsoft.Extensions.Logging;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;
using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Events.Reactions;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;
using Volvo.Registrations.Trucks.BusinessModels.Commons.Events;

namespace Volvo.Registrations.Trucks.Application.Commons.Events.Reactions;

public abstract class EventReaction<TEventReaction, TEventToReact> : IEventReaction
{
    protected readonly IDomainEventsPersistencyGateway DomainEventRepository;
    protected readonly ILogger<TEventReaction> Logger;
    protected readonly IMediator Mediator;

    public EventReaction(
        IDomainEventsPersistencyGateway domainEventRepository,
        ILogger<TEventReaction> logger,
        IMediator mediator
    )
    {
        DomainEventRepository = domainEventRepository;
        Logger = logger;
        Mediator = mediator;
    }

    public virtual async Task Execute(Guid eventId)
    {
        (var eventContent, var @event) = await GetEventContentDesserialized(eventId);

        var domainEvents = await Execute(eventContent, @event);

        foreach (var domainEvent in domainEvents)
        {
            domainEvent.SetPreviousEventId(eventId);
        }
        await DomainEventRepository.RegisterMany(domainEvents);

        foreach (var domainEvent in domainEvents)
            await Mediator.Publish(domainEvent);
    }

    protected virtual async Task<(TEventToReact, IDomainEvent)> GetEventContentDesserialized(Guid eventId)
    {
        try
        {
            var eventIdAsRequired = eventId;
            var @event = await DomainEventRepository.GetById(eventIdAsRequired);
            return (DomainEvent<TEventToReact>.Desserialize(@event.SerializedContent), @event);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, $"Error on {typeof(TEventReaction).FullName}.{nameof(GetEventContentDesserialized)} on event: {eventId}");
            throw;
        }
    }

    protected abstract Task<List<IDomainEvent>> Execute(TEventToReact content, IDomainEvent @event);
}