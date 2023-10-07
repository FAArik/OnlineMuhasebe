using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.AppDbContext;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.MainRoleAndRoleRelationshipRepositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.AppContext.MainRoleAndRoleRelationshipRepositories;

public class MainRoleAndRoleRelationshipQueryRepository : AppQueryRepository<MainRoleAndRoleRelationship>, IMainRoleAndRoleRelationshipQueryRepository
{
    public MainRoleAndRoleRelationshipQueryRepository(Context.AppDbContext context) : base(context) { }
}
