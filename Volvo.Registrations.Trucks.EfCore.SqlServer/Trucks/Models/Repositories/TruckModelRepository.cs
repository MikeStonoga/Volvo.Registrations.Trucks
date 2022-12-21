using System.Linq;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models.Views;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Models.Views;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities.Repositories;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Trucks.Models.Repositories;

public class TruckModelRepository : Repository<TruckModel, ITruckModel, IViewTruckModelGetAllForList>, ITruckModelPersistencyGateway
{
    public TruckModelRepository(TrucksDbContext currentDbContext) 
        : base(currentDbContext)
    {
    }

    public override IEnumerable<IViewTruckModelGetAllForList> MapBusinessModelToViewGetAllForList(List<TruckModel> truckModels)
       => truckModels.Select(truckModel =>  new ViewTruckModelGetAllForList(truckModel));
}
