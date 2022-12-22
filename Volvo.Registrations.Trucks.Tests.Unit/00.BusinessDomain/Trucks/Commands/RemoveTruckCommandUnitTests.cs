using Volvo.Registrations.Trucks.BusinessModels.Trucks.Commands;
using Volvo.Registrations.Trucks.Tests.Unit._00.BusinessDomain.Trucks.Utils;
using Volvo.Registrations.Trucks.Tests.Unit.Abstractions._00.BusinessDomain.Trucks.Commands;

namespace Volvo.Registrations.Trucks.Tests.Unit._00.BusinessDomain.Trucks.Commands;

public class RemoveTruckCommandUnitTests : IRemoveTruckCommandUnitTests
{
    [Test]
    public void ItRemovesSucessfully()
    {
        // Arrange
        var truck = TrucksUnitTestsUtils.GetValidTruck();
        var requirement = new RemoveTruckDTO.Requirement();
        requirement.TruckId = truck.Id;

        // Act
        truck.Remove(requirement);

        // Assert
        Assert.That(truck.IsDeleted, Is.True);
        Assert.That(truck.DeletionTime, Is.Not.Null);
    }
}
