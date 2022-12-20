using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Methods;

public interface ICanRegister<TRequirement>
{
    ITruck Register(TRequirement requirement);
}
