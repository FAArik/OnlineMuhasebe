using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbContext;

namespace OnlineMuhasebeServer.Domain.Repositories.AppContext.CompanyRepositories;

public interface ICompanyDbCommandRepository:IAppCommandRepository<Company>
{
}
