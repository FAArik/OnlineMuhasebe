using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.AppDbContext;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.MainRoleAndRoleRelationshipRepositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.AppContext.MainRoleAndRoleRelationshipRepositories;

public class MainRoleAndRoleRelationshipCommandRepository : AppCommandRepository<MainRoleAndRoleRelationship>, IMainRoleAndRoleRelationshipCommandRepository
{
    public MainRoleAndRoleRelationshipCommandRepository(Context.AppDbContext context) : base(context) { }
}
