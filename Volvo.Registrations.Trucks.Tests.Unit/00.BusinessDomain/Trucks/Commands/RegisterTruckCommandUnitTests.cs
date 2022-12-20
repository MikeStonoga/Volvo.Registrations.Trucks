using Volvo.Registrations.Trucks.BusinessModels.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Commands;
using Volvo.Registrations.Trucks.Tests.Unit.Abstractions._00.BusinessDomain.Trucks.Commands;

namespace Volvo.Registrations.Trucks.Tests.Unit._00.BusinessDomain.Trucks.Commands;

public class RegisterTruckCommandUnitTests : IRegisterTruckCommandUnitTests
{
    [Test]
    public void ItRegisterSuccessfully()
    {
        // Arrange
        var requirement = new RegisterTruckDTO.Requirement(
            modelId: Guid.NewGuid()
        );

        // Act
        Assert.That(() => Truck.Register(requirement), Throws.Nothing);
        var truckRegistered = Truck.Register(requirement);

        // Assert
        Assert.That(truckRegistered, Is.Not.Null);
        Assert.That(truckRegistered.Id, Is.Not.EqualTo(Guid.Empty));
        Assert.That(truckRegistered.ModelId, Is.Not.EqualTo(Guid.Empty));
        Assert.That(truckRegistered.ModelId, Is.EqualTo(requirement.ModelId));
        Assert.That(truckRegistered.ManufacturingYear, Is.EqualTo(DateTime.UtcNow.Year));
    }
}
