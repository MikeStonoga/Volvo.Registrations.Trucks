namespace Volvo.Registrations.Trucks.Application.Abstractions.Commons.Events.Reactions;

public interface IEventReaction
{
    Task Execute(Guid eventId);
}
