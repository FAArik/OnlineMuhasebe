using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Domain.Repositories.CompanyContext.UCAFRepositories;

public interface IUCAFQueryRepository : ICompanyQueryRepository<UniformChartOfAccount>
{
}
