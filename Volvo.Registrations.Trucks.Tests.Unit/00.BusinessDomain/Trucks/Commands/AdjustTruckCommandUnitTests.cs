using Volvo.Registrations.Trucks.BusinessModels.Trucks.Commands;
using Volvo.Registrations.Trucks.Tests.Unit._00.BusinessDomain.Trucks.Utils;
using Volvo.Registrations.Trucks.Tests.Unit.Abstractions._00.BusinessDomain.Trucks.Commands;

namespace Volvo.Registrations.Trucks.Tests.Unit._00.BusinessDomain.Trucks.Commands;

public class AdjustTruckCommandUnitTests : IAdjustTruckCommandUnitTests
{
    [Test]
    public void IAdjustsSucessfully()
    {
        // Arrange
        var truck = TrucksUnitTestsUtils.GetValidTruck();
        var requirement = TrucksUnitTestsUtils.GetValidAdjustTruckRequirement(truck);

        // Act
        truck.Adjust(requirement);

        // Assert
        Assert.That(truck.Name, Is.EqualTo(requirement.Name));
        Assert.That(truck.ModelId, Is.EqualTo(requirement.ModelId));
        Assert.That(truck.LastModificationTime, Is.Not.Null);
    }

    [Test]
    public void ItFailsWhenTryingToAdjustAlreadyRemovedTruck()
    {
        // Arrange
        var truck = TrucksUnitTestsUtils.GetValidTruck();
        truck.MarkAsDeleted();
        var requirement = TrucksUnitTestsUtils.GetValidAdjustTruckRequirement(truck);

        // Act
        // Assert
        Assert.That(() => truck.Adjust(requirement), Throws.Exception);
    }
}
