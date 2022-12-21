using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Methods;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Trucks.Models;

namespace Volvo.Registrations.Trucks.BusinessModels.Trucks;

public class Truck : BusinessModel, ITruck
{
    #region Properties
    public int ManufacturingYear { get; private set; }
    public Guid ModelId { get; private set; }
    public ITruckModel TruckModel { get; private set; }
    #endregion

    #region Constructors
    protected Truck() { }

    protected Truck(IRegisterTruckRequirement requirement)
        : base(id: Guid.NewGuid())
    {
        ModelId = requirement.ModelId;
        ManufacturingYear = DateTime.UtcNow.Year;
    }
    #endregion

    #region Methods
    public static ITruck Register(IRegisterTruckRequirement requirement)
        => new Truck(requirement);

    ITruck ICanRegister<IRegisterTruckRequirement>.Register(IRegisterTruckRequirement requirement)
        => Truck.Register(requirement);

    public void Adjust(IAdjustTruckRequirement requirement)
    {
        if (IsDeleted)
            throw new Exception($"This truck was removed and cannot be adjusted!");

        if (requirement.HasManufacturingYear)
            ManufacturingYear = requirement.ManufacturingYear.Value;

        if (requirement.HasModelId)
            ModelId = requirement.ModelId.Value;

        MarkAsModified();
    }

    public void Remove(IRemoveTruckRequirement requirement)
    {
        if (!IsDeleted)
            MarkAsDeleted();
    }
    #endregion
}
