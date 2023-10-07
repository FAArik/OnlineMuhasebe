using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.AppDbContext;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.MainRoleAndUserRelationshipRepositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.AppContext.MainRoleAndUserRelationshipRepositories;

public class MainRoleAndUserRelationshipQueryRepository : AppQueryRepository<MainRoleAndUserRelationship>, IMainRoleAndUserRelationshipQueryRepository
{
    public MainRoleAndUserRelationshipQueryRepository(Context.AppDbContext context) : base(context) { }
}
