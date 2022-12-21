using System.Security.Principal;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Commons.DTOs;

namespace Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;

public interface IPersistencyGateway<TIBusinessModel>
    where TIBusinessModel : IBusinessModel
{
    Task<ISet<TIBusinessModel>> GetAll();
    Task<TIBusinessModel> GetById(Guid businessModelId);
    Task<GetAllForListDTO.Result<dynamic>> GetAllForList(GetAllForListDTO.Requirement requirement);
    Task<TIBusinessModel> Insert(TIBusinessModel businessModel);
    Task<ISet<TIBusinessModel>> InsertMany(IEnumerable<TIBusinessModel> businessModels);
    Task<TIBusinessModel> Update(TIBusinessModel businessModel);
    Task Delete(Guid businessModelId);
    Task SoftDelete(TIBusinessModel businessModel);
}
