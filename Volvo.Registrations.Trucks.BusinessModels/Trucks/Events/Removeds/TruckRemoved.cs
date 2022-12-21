using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Events.Removeds;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Events.Removeds;

public class TruckRemoved : ITruckRemoved
{
    public Guid TruckId { get; private set; }

    private TruckRemoved() { }
    public TruckRemoved(Guid truckId)
    {
        TruckId = truckId;
    }
}
