using Volvo.Registrations.Trucks.BusinessModels.Commons.Events;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events.Extensions;

public static class DomainEventExtensions
{
    public static IDomainEvent ToDomainEvent<TContent>(this TContent content, string complement = "")
        => DomainEvent<TContent>.Create($"{typeof(TContent).Name} " + complement, content);
}
