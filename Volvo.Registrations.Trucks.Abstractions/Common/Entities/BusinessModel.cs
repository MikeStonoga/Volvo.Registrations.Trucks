namespace Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;

public abstract class BusinessModel : IBusinessModel
{
    #region Properties
    public Guid Id { get; private set; }
    public DateTime CreationTime { get; private set; }
    public DateTime? LastModificationTime { get; private set; }
    public DateTime? DeletionTime { get; private set; }
    public bool IsDeleted { get; private set; }
    #endregion

    #region Constructors
    protected BusinessModel() { }

    protected BusinessModel(Guid? id) 
    {
        Id = id ?? Guid.NewGuid();
        CreationTime = DateTime.UtcNow;
    }

    public void MarkAsModified()
    {
        LastModificationTime = DateTime.UtcNow;
    }

    public void MarkAsDeleted()
    {
        DeletionTime = DateTime.UtcNow;
        IsDeleted = true;
    }
    #endregion

    #region Methods
    #endregion
}
