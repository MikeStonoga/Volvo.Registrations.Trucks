
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Views;

public interface IView
    : IHaveId, 
    IHaveCode
{
    string CreationTime { get; }
    string? LastModificationTime { get; }
}
