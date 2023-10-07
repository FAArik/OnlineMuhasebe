using OnlineMuhasebeServer.Domain.Abstractions;
using System.Linq.Expressions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories;

public interface IQueryGenericRepository<T> where T :Entity
{
    IQueryable<T> GetAll(bool isTracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true);
    Task<T> GetById(string Id, bool isTracking = true);
    Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression,CancellationToken cancellationToken, bool isTracking = true);
    Task<T> GetFirst(bool isTracking = true);
}
