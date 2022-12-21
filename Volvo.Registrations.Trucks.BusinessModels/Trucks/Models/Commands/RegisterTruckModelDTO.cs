using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models.Commands;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Models.Commands;

public abstract class RegisterTruckModelDTO
{
    public class Requirement : IRegisterTruckModelRequirement
    {
        public string Name { get; set; }
        public int Year { get; set; }


        public Requirement()
        {
        }

        public Requirement(string name, int year)
        {
            Name = name;
            Year = year;
        }

    }
}
