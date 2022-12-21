using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Models;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities.Repositories;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Trucks.Models.Repositories;

public class TruckModelRepository : Repository<TruckModel, ITruckModel>, ITruckModelPersistencyGateway
{
    public TruckModelRepository(TrucksDbContext currentDbContext) 
        : base(currentDbContext)
    {
    }
}
