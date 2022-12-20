using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models.Commands;

public interface IRegisterTruckModelRequirement
    : IHaveName,
    IHaveYear
{
}
