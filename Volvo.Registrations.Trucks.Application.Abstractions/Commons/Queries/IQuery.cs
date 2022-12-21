using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Commons.DTOs;

namespace Volvo.Registrations.Trucks.Application.Abstractions.Commons.Queries;

public interface IQueries<TIBusinessModel>
    where TIBusinessModel : IBusinessModel
{
    Task<TIBusinessModel> GetById(Guid id);
    Task<ISet<TIBusinessModel>> GetAll();
    Task<GetAllForListDTO.Result<dynamic>> GetAllForList(GetAllForListDTO.Requirement requirement);

}
