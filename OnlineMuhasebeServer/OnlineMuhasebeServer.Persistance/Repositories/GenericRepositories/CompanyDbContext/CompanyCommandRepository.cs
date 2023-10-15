using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;

public class CompanyCommandRepository<T> : ICompanyCommandRepository<T> where T : Entity
{
    private static readonly Func<Context.CompanyDbContext, string, Task<T>> GetByIdCompiled = EF.CompileAsyncQuery((Context.CompanyDbContext context, string id) => context.Set<T>().FirstOrDefault(p => p.Id == id));

    private Context.CompanyDbContext _context; 

    public DbSet<T> Entity { get; set; }

    public void SetDbContexInstance(DbContext context)
    {
        _context = (Context.CompanyDbContext)context;
        Entity = _context.Set<T>();
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await Entity.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        await Entity.AddRangeAsync(entities, cancellationToken);
    }

    public void Remove(T entity)
    {
        Entity.Remove(entity);
    }

    public async Task RemoveById(string Id)
    {
        T entity = await GetByIdCompiled(_context, Id);
        Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        Entity.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        Entity.UpdateRange(entities);
    }
}
