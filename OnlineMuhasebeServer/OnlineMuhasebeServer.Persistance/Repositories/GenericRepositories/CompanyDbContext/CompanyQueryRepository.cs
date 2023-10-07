using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;
using System.Linq.Expressions;

namespace OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;

public class CompanyQueryRepository<T> : ICompanyQueryRepository<T> where T : Entity
{
    private static readonly Func<Context.CompanyDbContext, string, bool, Task<T>> GetByIdCompiled = EF.CompileAsyncQuery((Context.CompanyDbContext context, string id, bool isTracking) => isTracking == true ? context.Set<T>().FirstOrDefault(p => p.Id == id) : context.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id));
    private static readonly Func<Context.CompanyDbContext, bool, Task<T>> GetFirstCompiled = EF.CompileAsyncQuery((Context.CompanyDbContext context, bool isTracking) => isTracking == true ? context.Set<T>().FirstOrDefault() : context.Set<T>().AsNoTracking().FirstOrDefault());
   
    private Context.CompanyDbContext _context;
    public DbSet<T> Entity { get; set; }

    public void SetDbContexInstance(DbContext context)
    {
        _context = (Context.CompanyDbContext)context;
        Entity = _context.Set<T>();
    }

    public IQueryable<T> GetAll(bool isTracking = true)
    {
        var result = Entity.AsQueryable();
        if (!isTracking)
        {
            result = Entity.AsNoTracking();
        }
        return result;
    }

    public async Task<T> GetById(string Id, bool isTracking = true)
    {
        return await GetByIdCompiled(_context, Id, isTracking);
    }

    public async Task<T> GetFirst(bool isTracking = true)
    {
        return await GetFirstCompiled(_context, isTracking);
    }

    public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, CancellationToken cancellationToken, bool isTracking = true)
    {
        T entity = null;
        if (!isTracking)
        {
            entity = await Entity.AsNoTracking().FirstOrDefaultAsync(expression);
        }
        else
        {
            entity = await Entity.FirstOrDefaultAsync(expression);
        }
        return entity;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var result = Entity.Where(expression);
        if (!isTracking)
        {
            result = Entity.AsNoTracking();
        }
        return result;
    }

}
