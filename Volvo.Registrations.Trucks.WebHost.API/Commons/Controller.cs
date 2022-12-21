using Microsoft.AspNetCore.Mvc;
using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Queries;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Views;
using Volvo.Registrations.Trucks.BusinessModels.Commons.DTOs;

namespace Volvo.Registrations.Trucks.WebHost.API.Commons;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class Controller<TIBusinessModel, TIBusinessModelQueriesAndCommands> : ControllerBase
        where TIBusinessModel : IBusinessModel
        where TIBusinessModelQueriesAndCommands : IQueries<TIBusinessModel>
{
    protected readonly TIBusinessModelQueriesAndCommands QueriesAndCommands;

    public Controller(TIBusinessModelQueriesAndCommands queriesAndCommands)
    {
        QueriesAndCommands = queriesAndCommands;
    }

    [HttpGet]
    public virtual async Task<IActionResult> GetById([FromQuery] Guid id)
        => Ok(await QueriesAndCommands.GetById(id));

    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
        => Ok(await QueriesAndCommands.GetAll());

    [HttpPost]
    public async Task<IActionResult> GetAllForList(GetAllForListDTO.Requirement requirement)
        => Ok(await QueriesAndCommands.GetAllForList(requirement));

    protected async Task<IActionResult> TryExecuteEndpoint<TResult>(Func<Task<TResult>> queryOrCommandServiceCall)
    {
        try
        {
            var result = await queryOrCommandServiceCall();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Problem($"There was an unexpected error! {ex.Message}");
        }
    }
}