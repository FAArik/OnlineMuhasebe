using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.CompanyRepositories;
using OnlineMuhasebeServer.Persistance.Context;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.AppDbContext;

namespace OnlineMuhasebeServer.Persistance.Repositories.AppContext.CompanyRepositories;

public sealed class CompanyDbCommandRepository : AppCommandRepository<Company>, ICompanyDbCommandRepository
{
    public CompanyDbCommandRepository(AppDbContext context) : base(context)
    {
    }
}
