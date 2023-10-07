using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories;

public interface IRepository<T> where T :Entity
{
    public DbSet<T> Entity { get; set; }
}
