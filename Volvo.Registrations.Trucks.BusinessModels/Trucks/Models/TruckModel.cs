using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models.Commands;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Models;

public class TruckModel : BusinessModel, ITruckModel
{
    public string Name { get; private set; }
    public DateTime Year { get; private set; }


    public TruckModel(IRegisterTruckModelRequirement requirement)
        : base(id: Guid.NewGuid())
    {
        Name = requirement.Name;
        Year = requirement.Year;
    }
}
