using Volvo.Registrations.Trucks.Adapters.BackgroundProcessing;
using Volvo.Registrations.Trucks.Application.Commons.Events.Handlers;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Events.Removeds;

namespace Volvo.Registrations.Trucks.Application.Trucks.Events.Removed;

public class TruckRemovedHandler : EventHandler<TruckRemovedHandler, TruckRemoved>
{
    public TruckRemovedHandler(IBackgroundProcessingService backgroundProcessingService) 
        : base(backgroundProcessingService)
    {
    }
}
