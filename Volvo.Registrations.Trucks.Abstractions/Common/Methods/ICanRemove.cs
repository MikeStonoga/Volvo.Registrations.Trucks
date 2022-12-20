namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Methods;

public interface ICanRemove<TRequirement>
{
    void Remove(TRequirement requirement);
}