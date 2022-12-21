using Volvo.Registrations.Trucks.Adapters.BackgroundProcessing;
using Volvo.Registrations.Trucks.Application.Commons.Events.Handlers;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Events.Adjusteds;

namespace Volvo.Registrations.Trucks.Application.Trucks.Events.Adjusted;

public class TruckAdjustedHandler : EventHandler<TruckAdjustedHandler, TruckAdjusted>
{
    public TruckAdjustedHandler(IBackgroundProcessingService backgroundProcessingService) 
        : base(backgroundProcessingService)
    {
    }
}
