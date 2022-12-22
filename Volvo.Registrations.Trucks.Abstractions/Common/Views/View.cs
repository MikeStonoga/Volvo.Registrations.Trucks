using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;

namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Views;

public abstract class View<TIBusinessModel> : IView
    where TIBusinessModel : IBusinessModel
{
    public Guid Id { get; private set; }
    public int Code { get; private set; }
    public string CreationTime { get; private set; }
    public string? LastModificationTime { get; private set; }

    protected View(TIBusinessModel businessModel)
    {
        Id = businessModel.Id;
        Code = businessModel.Code;
        CreationTime = businessModel.CreationTime.ToString("g");
        LastModificationTime = businessModel.LastModificationTime?.ToString("g");
    }

}
