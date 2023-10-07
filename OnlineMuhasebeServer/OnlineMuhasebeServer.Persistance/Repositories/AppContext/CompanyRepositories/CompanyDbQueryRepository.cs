using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.CompanyRepositories;
using OnlineMuhasebeServer.Persistance.Context;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.AppDbContext;

namespace OnlineMuhasebeServer.Persistance.Repositories.AppContext.CompanyRepositories;

public sealed class CompanyDbQueryRepository : AppQueryRepository<Company>, ICompanyDbQueryRepository
{
    public CompanyDbQueryRepository(AppDbContext context) : base(context)
    {
    }
}
