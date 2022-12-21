using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;
using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Queries;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Commons.DTOs;

namespace Volvo.Registrations.Trucks.Application.Commons.Queries;

public abstract class Queries<TIBusinessModel, TIBusinessModelDataAccessGateway, TIViewGetAllForList> : IQueries<TIBusinessModel>
       where TIBusinessModel : IBusinessModel
       where TIBusinessModelDataAccessGateway : IPersistencyGateway<TIBusinessModel>
{
    protected readonly TIBusinessModelDataAccessGateway PersistencyGateway;

    public Queries(TIBusinessModelDataAccessGateway persistencyGateway)
    {
        PersistencyGateway = persistencyGateway;
    }

    public virtual async Task<TIBusinessModel> GetById(Guid id)
    {
        var result = await PersistencyGateway.GetById(id);
        return result;
    }

    public virtual async Task<ISet<TIBusinessModel>> GetAll()
    {
        var results = await PersistencyGateway.GetAll();
        return results;
    }

    public async Task<GetAllForListDTO.Result<dynamic>> GetAllForList(GetAllForListDTO.Requirement requirement)
    {
        var resultado = await PersistencyGateway.GetAllForList(requirement);
        return resultado;
    }
}