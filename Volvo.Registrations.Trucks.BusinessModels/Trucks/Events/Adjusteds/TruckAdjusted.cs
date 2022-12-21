using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Events.Adjusteds;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Events.Adjusteds;

public class TruckAdjusted : ITruckAdjusted
{
    public ITruck Truck { get; private set; }

    private TruckAdjusted() { }
    public TruckAdjusted(ITruck truck)
    {
        Truck = truck;
    }
}
