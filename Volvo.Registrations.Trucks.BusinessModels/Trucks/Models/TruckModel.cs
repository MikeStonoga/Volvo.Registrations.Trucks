using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models.Commands;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Models;

public class TruckModel : BusinessModel, ITruckModel
{
    public string Name { get; private set; }
    public int Year { get; private set; }


    private TruckModel() { }
    public TruckModel(IRegisterTruckModelRequirement requirement)
        : base(id: Guid.NewGuid())
    {
        Name = requirement.Name;
        Year = ValidateYear(requirement.Year); 
    }

    private int ValidateYear(int year)
    {
        var now = DateTime.UtcNow;
        bool canParse = DateTime.TryParse($"01/01/{year}", out DateTime validated);
        bool isThisYear = validated.Year == now.Year;
        bool isNextYear = validated.Year == now.AddYears(1).Year;
        bool isValid = canParse && (isThisYear || isNextYear);
        return isValid
            ? validated.Year 
            : throw new Exception("Invalid Year!");
    }
}
