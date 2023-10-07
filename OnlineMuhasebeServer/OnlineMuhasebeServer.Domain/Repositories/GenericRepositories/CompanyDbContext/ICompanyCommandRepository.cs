using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Domain.Repositories;

public interface ICompanyCommandRepository<T>:ICompanyRepository<T>, ICommandGenericRepository<T> where T:Entity
{
    
}
