using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext
{
    public interface ICompanyQueryRepository<T> : ICompanyRepository<T>,IQueryGenericRepository<T> where T : Entity
    {
       
    }
}
