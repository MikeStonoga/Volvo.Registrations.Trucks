using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Properties;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Views;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models.Views;

public interface IViewTruckModelGetAllForList 
    : IView, IHaveYear, IHaveName
{
}
