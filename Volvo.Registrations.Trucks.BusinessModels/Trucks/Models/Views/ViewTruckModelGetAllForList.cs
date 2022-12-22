using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Views;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models.Views;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Models.Views;

public class ViewTruckModelGetAllForList : View<ITruckModel>, IViewTruckModelGetAllForList
{
    public Guid Id { get; private set; }
    public int Year { get; private set; }
    public string Name { get; private set; }


    public ViewTruckModelGetAllForList(ITruckModel truckModel)
        : base(truckModel)
    {
        Id = truckModel.Id;
        Name = truckModel.Name;
        Year = truckModel.Year;

    }
}
