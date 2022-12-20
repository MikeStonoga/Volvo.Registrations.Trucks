using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;

namespace Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;

public interface IPersistencyGateway<TIBusinessModel>
    where TIBusinessModel : IBusinessModel
{
    Task<IEnumerable<IBusinessModel>> GetAll();
    Task<TIBusinessModel> GetById(Guid businessModelId); 
    Task<TIBusinessModel> Insert(TIBusinessModel businessModel);
    Task<TIBusinessModel> Update(TIBusinessModel businessModel);
    Task Delete(Guid businessModelId);
}
