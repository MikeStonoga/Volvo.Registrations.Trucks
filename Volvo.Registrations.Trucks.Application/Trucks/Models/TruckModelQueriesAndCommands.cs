using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Trucks.Models;
using Volvo.Registrations.Trucks.Application.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.Application.Commons.Queries;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models.Views;

namespace Volvo.Registrations.Trucks.Application.Trucks.Models;

public class TruckModelQueriesAndCommands : Queries<ITruckModel, ITruckModelPersistencyGateway, IViewTruckModelGetAllForList>, ITruckModelQueriesAndCommands
{
    public TruckModelQueriesAndCommands(ITruckModelPersistencyGateway persistencyGateway) 
        : base(persistencyGateway)
    {
    }
}
