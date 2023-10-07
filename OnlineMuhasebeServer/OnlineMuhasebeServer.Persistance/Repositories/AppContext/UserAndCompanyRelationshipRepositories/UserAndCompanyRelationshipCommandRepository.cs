using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.AppDbContext;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.UserAndCompanyRelationshipRepositories;

namespace OnlineMuhasebeServer.Persistance.Repositories.AppContext.UserAndCompanyRelationshipRepositories;

public class UserAndCompanyRelationshipCommandRepository : AppCommandRepository<UserAndCompanyRelationship>, IUserAndCompanyRelationshipCommandRepository
{
    public UserAndCompanyRelationshipCommandRepository(Context.AppDbContext context) : base(context) { }
}
