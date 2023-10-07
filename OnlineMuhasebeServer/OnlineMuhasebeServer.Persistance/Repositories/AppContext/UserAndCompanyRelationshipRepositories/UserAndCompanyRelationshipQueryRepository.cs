using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.AppDbContext;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.UserAndCompanyRelationshipRepositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.AppContext.UserAndCompanyRelationshipRepositories;

public class UserAndCompanyRelationshipQueryRepository : AppQueryRepository<UserAndCompanyRelationship>, IUserAndCompanyRelationshipQueryRepository
{
    public UserAndCompanyRelationshipQueryRepository(Context.AppDbContext context) : base(context) { }
}
