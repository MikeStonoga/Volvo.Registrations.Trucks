using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Views;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks.Views;

public class ViewTruckGetAllForList : IViewTruckGetAllForList
{
    public string Model { get; private set; }
    public int ManufacturingYear { get; private set; }

    public ViewTruckGetAllForList(ITruck truck)
    {
        Model = $"{truck.TruckModel.Name} / {truck.TruckModel.Year}";
        ManufacturingYear = truck.ManufacturingYear;
    }

}
