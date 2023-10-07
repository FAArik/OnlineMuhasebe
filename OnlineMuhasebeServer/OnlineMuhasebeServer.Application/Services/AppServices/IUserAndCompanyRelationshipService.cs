
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppServices;

public interface IUserAndCompanyRelationshipService
{
    Task CreateAsync(UserAndCompanyRelationship userAndCompanyRelationship, CancellationToken cancellationToken);
    Task RemoveByIdAsync(string Id);
    Task<UserAndCompanyRelationship> GetByIdAsync(string Id);
    Task<UserAndCompanyRelationship> GetByUserIdAndCompanyId(string UserId, string CompanyId, CancellationToken cancellationToken);
    Task<IList<UserAndCompanyRelationship>> GetListByUserId(string UserId);

}
