namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Methods;

public interface ICanAdjust<TRequirement>
{
    void Adjust(TRequirement requirement);
}
