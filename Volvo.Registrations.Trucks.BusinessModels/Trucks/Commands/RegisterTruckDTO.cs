using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Commands;

public abstract class RegisterTruckDTO
{
    public class Requirement : IRegisterTruckRequirement
    {
        public Guid ModelId { get; set; }

        public Requirement()
        {
        }

        public Requirement(Guid modelId)
        {
            ModelId = modelId;
        }
    }

    public class Result : IRegisterTruckResult
    {
        public ITruck Truck { get; private set; }

        public Result(ITruck truck)
        {
            Truck = truck;
        }
    }
}
