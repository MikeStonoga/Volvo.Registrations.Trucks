using Microsoft.EntityFrameworkCore;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities.Repositories;
public abstract class Repository<TBusinessModel, TIBusinessModel> : IPersistencyGateway<TIBusinessModel>
    where TBusinessModel : class, TIBusinessModel
    where TIBusinessModel : IBusinessModel
{
    // private readonly Func<string, TBusinessModel, bool> _filtrarDaLista;

    public TrucksDbContext DbContext { get; set; }

    public Repository(TrucksDbContext currentDbContext)// , Func<string, TBusinessModel, bool> FiltrarDaLista)
    {
        DbContext = currentDbContext;
        // _filtrarDaLista = FiltrarDaLista;
    }

    public virtual async Task<TIBusinessModel> GetById(Guid id)
    {
        var resultado = await DbContext.Set<TBusinessModel>().FirstAsync(e => e.Id == id && !e.IsDeleted);
        return resultado;
    }

    public virtual async Task<ISet<TIBusinessModel>> GetAll()
    {
        var resultado = await DbContext.Set<TBusinessModel>().Where(e => !e.IsDeleted).ToListAsync();
        return resultado.ToHashSet<TIBusinessModel>();
    }

    /*public virtual async Task<ObterTodosParaExibirNaListaDTO.Resultado<TIBusinessModel>> ObterTodosParaExibirNaLista(ObterTodosParaExibirNaListaDTO.Requisito requisito)
    {
        var totalCount = await DbContext.Set<TBusinessModel>()
            .Where(e => !requisito.IdsToIgnore.Contains(e.Id))
            .CountAsync();

        if (totalCount <= 0)
            return new(new List<TIBusinessModel>(0), 0);

        var queryFiltrada = DbContext.Set<TBusinessModel>()
            .Where(e => !requisito.IdsToIgnore.Contains(e.Id))
            // TODO: ajustar filtro
            // .Where(e => _filtrarDaLista(requisito.Filter, e))
            ;

        var queryOrdernada = requisito.Sort.Direction == "desc"
            ? queryFiltrada.OrderByDescending(MemberSelector<TBusinessModel, object>(requisito.Sort.ColumnName))
            : queryFiltrada.OrderBy(MemberSelector<TBusinessModel, object>(requisito.Sort.ColumnName));

        var resultado = await queryOrdernada
            .Skip(requisito.Pagination.SkipCount)
            .Take(requisito.Pagination.PageSize)
            .ToListAsync();

        return new ObterTodosParaExibirNaListaDTO.Resultado<TIBusinessModel>(resultado, totalCount);
    }

    static Expression<Func<T, TValue>> MemberSelector<T, TValue>(string name)
    {
        var parameter = Expression.Parameter(typeof(T), "item");
        var body = Expression.PropertyOrField(expression: parameter, name);
        return Expression.Lambda<Func<T, TValue>>(Expression.Convert(body, typeof(object)), parameter);
    }*/

    public async Task<TIBusinessModel> Insert(TIBusinessModel businessModel)
    {
        await DbContext.AddAsync((TBusinessModel)businessModel);

        if (DbContext.Database.CurrentTransaction == null)
            await DbContext.SaveChangesAsync();

        return businessModel;
    }

    public async Task<ISet<TIBusinessModel>> InsertMany(IEnumerable<TIBusinessModel> businessModels)
    {
        if (!businessModels.Any())
            return businessModels.ToHashSet();

        await DbContext.AddRangeAsync(businessModels.Select(e => (TBusinessModel)e));

        if (DbContext.Database.CurrentTransaction == null)
            await DbContext.SaveChangesAsync();

        return businessModels.ToHashSet();
    }

    public async Task<TIBusinessModel> Update(TIBusinessModel businessModel)
    {
        businessModel.MarkAsModified();
        DbContext.Update((TBusinessModel)businessModel);

        if (DbContext.Database.CurrentTransaction == null)
            await DbContext.SaveChangesAsync();

        return businessModel;
    }

    public async Task Delete(Guid businessModelId)
    {
        var entityToDelete = await GetById(businessModelId);
        if (entityToDelete != null)
            DbContext.Remove(entityToDelete);

        if (DbContext.Database.CurrentTransaction == null)
            await DbContext.SaveChangesAsync();
    }

    public async Task SoftDelete(TIBusinessModel businessModel)
    {
        businessModel.MarkAsDeleted();
        await Update(businessModel);
    }
}
