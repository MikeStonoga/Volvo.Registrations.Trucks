﻿using MediatR;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;

public interface IDomainEvent : IBusinessModel, IHaveName, INotification
{
    string SerializedContent { get; }
    Guid? PreviousDomainEventId { get; }
}

public interface IDomainEvent<TContent> : IDomainEvent
{
    public TContent ContentValue { get; }
}