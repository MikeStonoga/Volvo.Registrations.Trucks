namespace Volvo.Registrations.Trucks.Tests.Unit.Abstractions._00.BusinessDomain.Trucks.Commands;

public interface IRegisterTruckCommandUnitTests
{
    void ItRegisterSuccessfully();
    void ItFailsWithEmptyName();
    void ItFailsWithNoTruckModelInformed();
}
