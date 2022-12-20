using MediatR;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;

namespace Volvo.Registrations.Trucks.Application.Abstractions.Commons.Events.Handlers;

public interface IEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}
