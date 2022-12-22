using Volvo.Registrations.Trucks.BusinessModels.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Commands;

namespace Volvo.Registrations.Trucks.Tests.Unit._00.BusinessDomain.Trucks.Utils
{
    public static class TrucksUnitTestsUtils
    {
        public static RegisterTruckDTO.Requirement GetValidRegisterTruckRequirement()
        {
            var requirement = new RegisterTruckDTO.Requirement();
            requirement.ModelId = Guid.NewGuid();
            requirement.Name = "Truck One";
            return requirement;
        }

        public static Truck GetValidTruck()
            => (Truck)Truck.Register(GetValidRegisterTruckRequirement());

        public static AdjustTruckDTO.Requirement GetValidAdjustTruckRequirement(Truck truckToAdjust)
        {
            var requirement = new AdjustTruckDTO.Requirement();
            requirement.TruckId = truckToAdjust.Id;
            requirement.ModelId = Guid.NewGuid();
            requirement.Name = "Truck Two";
            return requirement;
        }
    }
}
