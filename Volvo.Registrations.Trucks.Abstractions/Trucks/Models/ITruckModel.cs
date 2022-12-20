using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models;

public interface ITruckModel 
    : IBusinessModel, 
    IHaveName,
    IHaveYear
{
}
