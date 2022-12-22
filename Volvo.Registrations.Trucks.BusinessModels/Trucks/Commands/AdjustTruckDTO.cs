using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Commands;

public abstract class AdjustTruckDTO
{
    public class Requirement : IAdjustTruckRequirement
    {
        public Guid TruckId { get; set; }
        public Guid? ModelId { get; set; }
        public string? Name { get; set; }
    }

    public class Result : IAdjustTruckResult
    {
        public ITruck Truck { get; private set; }

        public Result(ITruck truck)
        {
            Truck = truck;
        }
    }
}
