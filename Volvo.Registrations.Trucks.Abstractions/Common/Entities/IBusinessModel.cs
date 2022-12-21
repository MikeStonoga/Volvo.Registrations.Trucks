using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities.Properties;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;

public interface IBusinessModel
    : IHaveId,
    IHaveCreationInfo,
    IHaveLastModificationInfo,
    IHaveSoftDelete
{    
}
