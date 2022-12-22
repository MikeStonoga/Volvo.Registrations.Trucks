using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;

public interface IRegisterTruckRequirement 
    : IHaveModelId,
    IHaveName
{
}
