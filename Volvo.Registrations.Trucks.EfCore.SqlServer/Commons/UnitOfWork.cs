using Microsoft.EntityFrameworkCore.Storage;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Commons;

public class UnitOfWork : IUnitOfWork
{
    public IDbContextTransaction Transaction { get; protected set; }

    public bool HasOpenTransaction => _context.Database.CurrentTransaction != null;

    private readonly TrucksDbContext _context;

    public UnitOfWork(TrucksDbContext context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        Transaction = transaction;
    }

    public async Task Commit()
    {
        await Transaction.CommitAsync();
        await _context.SaveChangesAsync();
    }

    public async Task Rollback()
        => await Transaction.RollbackAsync();
}