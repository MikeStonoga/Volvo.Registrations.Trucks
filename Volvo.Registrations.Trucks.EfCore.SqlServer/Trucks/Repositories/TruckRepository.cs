using Microsoft.EntityFrameworkCore;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Views;
using Volvo.Registrations.Trucks.BusinessModels.Commons.DTOs;
using Volvo.Registrations.Trucks.BusinessModels.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Views;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities.Repositories;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Trucks.Repositories;

public class TruckRepository : Repository<Truck, ITruck, IViewTruckGetAllForList>, ITruckPersistencyGateway
{
    public TruckRepository(TrucksDbContext currentDbContext) 
        : base(currentDbContext)
    {
    }

    public override async Task<ITruck> GetById(Guid id)
    {
        var resultado = await DbContext.Trucks
            .Include(e => e.TruckModel)
            .FirstAsync(e => e.Id == id && !e.IsDeleted);

        return resultado;
    }

    public override async Task<ISet<ITruck>> GetAll()
    {
        var resultado = await DbContext.Trucks
            .Include(e => e.TruckModel)
            .Where(e => !e.IsDeleted)
            .ToListAsync();

        return resultado.ToHashSet<ITruck>();
    }

    public override IEnumerable<IViewTruckGetAllForList> MapBusinessModelToViewGetAllForList(List<Truck> trucks)
       => trucks.Select(truck => new ViewTruckGetAllForList(truck));

    protected override IQueryable<Truck> GetAllForListQuery(GetAllForListDTO.Requirement requirement)
    {
        return base.GetAllForListQuery(requirement).Include(e => e.TruckModel);
    }
}
