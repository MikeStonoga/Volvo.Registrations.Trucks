namespace Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;

public interface IUnitOfWork
{
    bool HasOpenTransaction { get; }
    void BeginTransaction();
    Task Commit();
    Task Rollback();
}