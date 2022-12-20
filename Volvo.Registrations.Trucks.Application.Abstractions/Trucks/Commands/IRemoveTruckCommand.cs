using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;

namespace Volvo.Registrations.Trucks.Application.Abstractions.Trucks.Commands;

public interface IRemoveTruckCommand : ICommand<IRemoveTruckRequirement, IRemoveTruckResult>
{
}
