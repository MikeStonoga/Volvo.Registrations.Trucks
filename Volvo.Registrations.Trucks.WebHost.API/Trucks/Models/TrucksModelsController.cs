using Microsoft.AspNetCore.Mvc;
using System.Net;
using Volvo.Registrations.Trucks.Application.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Trucks.Models;
using Volvo.Registrations.Trucks.WebHost.API.Commons;

namespace Volvo.Registrations.Trucks.WebHost.API.Trucks.Models
{
    public class TrucksModelsController : Controller<ITruckModel, ITruckModelQueriesAndCommands>
    {
        public TrucksModelsController(ITruckModelQueriesAndCommands queriesAndCommands) 
            : base(queriesAndCommands)
        {
        }

        [ProducesResponseType(typeof(ActionResult<TruckModel>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> GetById([FromQuery] Guid id)
            => await base.GetById(id);

        [ProducesResponseType(typeof(ActionResult<HashSet<TruckModel>>), (int)HttpStatusCode.OK)]
        public override async Task<IActionResult> GetAll()
            => await base.GetAll();
    }
}
