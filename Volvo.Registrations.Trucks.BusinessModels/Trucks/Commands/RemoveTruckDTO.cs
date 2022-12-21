using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Commands;

public abstract class RemoveTruckDTO
{
    public class Requirement : IRemoveTruckRequirement
    {
        public Guid TruckId { get; set; }
    }

    public class Result : IRemoveTruckResult
    {
        public string Message { get; private set; }

        public Result()
        {
            Message = "Truck removed successfuly";
        }
    }
}
