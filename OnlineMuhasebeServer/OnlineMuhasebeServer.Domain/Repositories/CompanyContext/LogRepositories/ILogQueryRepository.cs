using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;


namespace OnlineMuhasebeServer.Domain.Repositories.CompanyContext.LogRepositories;

public interface ILogQueryRepository : ICompanyQueryRepository<Log>
{

}
