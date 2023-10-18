using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.ReportRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistance.Repositories.CompanyContext.ReportRepositories;

public class ReportQueryRepository : CompanyQueryRepository<Report>, IReportQueryRepository
{

}
