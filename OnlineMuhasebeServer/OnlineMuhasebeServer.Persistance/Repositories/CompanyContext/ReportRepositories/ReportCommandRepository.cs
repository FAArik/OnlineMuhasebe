using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.ReportRepositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.CompanyContext.ReportRepositories;

public class ReportCommandRepository : CompanyCommandRepository<Report>, IReportCommandRepository
{

}
