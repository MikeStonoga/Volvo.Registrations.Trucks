using Volvo.Registrations.Trucks.Adapters.BackgroundProcessing;
using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Events.Reactions;
using Volvo.Registrations.Trucks.Application.Commons.Events.Handlers;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Events.Registereds;

namespace Volvo.Registrations.Trucks.Application.Trucks.Events.Registereds;

public class TruckRegisteredHandler : EventHandler<TruckRegisteredHandler, TruckRegistered>
{
    public TruckRegisteredHandler(IBackgroundProcessingService backgroundProcessingService) 
        : base(backgroundProcessingService)
    {
    }
}
