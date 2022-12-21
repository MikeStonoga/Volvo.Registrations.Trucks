using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;
using Volvo.Registrations.Trucks.BusinessModels.Commons.Events;
using Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities.Repositories;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Events.Repositories;

public class DomainEventRepository : Repository<DomainEvent, IDomainEvent>, IDomainEventsPersistencyGateway
{
    public DomainEventRepository(TrucksDbContext currentDbContext) 
        : base(currentDbContext)
    {
    }

}
