using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.LogRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistance.Repositories.CompanyContext.LogRepositories;

public class LogCommandRepository : CompanyCommandRepository<Log>, ILogCommandRepository
{

}
