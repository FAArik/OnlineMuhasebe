using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.UCAFRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.CompanyDbContext;

namespace OnlineMuhasebeServer.Persistance.Repositories.CompanyContext.UCAFRepositories
{
    public class UCAFCommandRepository : CompanyCommandRepository<UniformChartOfAccount>, IUCAFCommandRepository
    {
    }
}
