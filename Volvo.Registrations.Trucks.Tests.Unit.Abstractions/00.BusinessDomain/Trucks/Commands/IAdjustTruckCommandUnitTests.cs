namespace Volvo.Registrations.Trucks.Tests.Unit.Abstractions._00.BusinessDomain.Trucks.Commands;

public interface IAdjustTruckCommandUnitTests
{
    void IAdjustsSucessfully();
    void ItFailsWhenTryingToAdjustAlreadyRemovedTruck();
}
