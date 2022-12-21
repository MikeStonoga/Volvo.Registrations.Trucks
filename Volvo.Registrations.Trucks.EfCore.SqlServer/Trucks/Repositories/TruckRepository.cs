using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Trucks;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities.Repositories;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Trucks.Repositories;

public class TruckRepository : Repository<Truck, ITruck>, ITruckPersistencyGateway
{
    public TruckRepository(TrucksDbContext currentDbContext) 
        : base(currentDbContext)
    {
    }
}
