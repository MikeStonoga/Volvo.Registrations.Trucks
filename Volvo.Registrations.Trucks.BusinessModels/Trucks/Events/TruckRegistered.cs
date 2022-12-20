using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Events;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Events;

public class TruckRegistered : ITruckRegistered
{
    public ITruck Truck { get; private set; }

    private TruckRegistered() { }
    public TruckRegistered(ITruck truck)
    {
        Truck = truck;
    }
}
