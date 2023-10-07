using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;

namespace OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;

public interface ICompanyRepository<T>:IRepository<T> where T :Entity
{
    void SetDbContexInstance(DbContext context);

}
