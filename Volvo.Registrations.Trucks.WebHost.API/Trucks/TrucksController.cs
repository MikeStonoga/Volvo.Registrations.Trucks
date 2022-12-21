using Microsoft.AspNetCore.Mvc;
using Volvo.Registrations.Trucks.Application.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Commands;
using Volvo.Registrations.Trucks.WebHost.API.Commons;

namespace Volvo.Registrations.Trucks.WebHost.API.Trucks;

public class TrucksController : Controller<ITruck, ITrucksCommandsAndQueries>
{
    public TrucksController(ITrucksCommandsAndQueries queriesAndCommands) 
        : base(queriesAndCommands)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterTruckDTO.Requirement requirement)
        => await TryExecuteEndpoint(async () => await QueriesAndCommands.Register(requirement));

    [HttpPatch]
    public async Task<IActionResult> Adjust([FromBody] AdjustTruckDTO.Requirement requirement)
       => await TryExecuteEndpoint(async () => await QueriesAndCommands.Adjust(requirement));

    [HttpDelete]
    public async Task<IActionResult> Remove([FromBody] RemoveTruckDTO.Requirement requirement)
       => await TryExecuteEndpoint(async () => await QueriesAndCommands.Remove(requirement));
}
