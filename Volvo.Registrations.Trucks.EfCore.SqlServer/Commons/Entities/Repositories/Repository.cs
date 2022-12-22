using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Commons.DTOs;

namespace Volvo.Registrations.Trucks.EfCore.SqlServer.Commons.Entities.Repositories;
public abstract class Repository<TBusinessModel, TIBusinessModel, TIViewGetAllForList> : IPersistencyGateway<TIBusinessModel>
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

    public virtual async Task<GetAllForListDTO.Result<dynamic>> GetAllForList(GetAllForListDTO.Requirement requirement)
    {
        var totalCount = await GetAllForListQuery(requirement)
            .Where(e => !requirement.IdsToIgnore.Contains(e.Id))
            .CountAsync();

        if (totalCount <= 0)
            return new(new List<dynamic>(0), 0);

        var filteredQuery = GetAllForListQuery(requirement)
            .Where(e => !requirement.IdsToIgnore.Contains(e.Id))
            // TODO: ajustar filtro
            // .Where(e => _filtrarDaLista(requisito.Filter, e))
            ;

        var OrdererdQuery = requirement.Sort.Direction == "desc"
            ? filteredQuery.OrderByDescending(MemberSelector<TBusinessModel, object>(requirement.Sort.ColumnName))
            : filteredQuery.OrderBy(MemberSelector<TBusinessModel, object>(requirement.Sort.ColumnName));

        var result = await OrdererdQuery
            .Skip(requirement.Pagination.SkipCount)
            .Take(requirement.Pagination.PageSize)
            .ToListAsync();

        return new GetAllForListDTO.Result<dynamic>(MapBusinessModelToViewGetAllForList(result), totalCount) ;
    }

    protected virtual IQueryable<TBusinessModel> GetAllForListQuery(GetAllForListDTO.Requirement requirement)
        => DbContext.Set<TBusinessModel>();


    public abstract IEnumerable<dynamic> MapBusinessModelToViewGetAllForList(List<TBusinessModel> result);

    static Expression<Func<T, TValue>> MemberSelector<T, TValue>(string name)
    {
        var parameter = Expression.Parameter(typeof(T), "item");
        var body = Expression.PropertyOrField(expression: parameter, name);
        return Expression.Lambda<Func<T, TValue>>(Expression.Convert(body, typeof(object)), parameter);
    }

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
        DbContext.Entry((TBusinessModel)businessModel).Property(x => x.Code).IsModified = false;

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
