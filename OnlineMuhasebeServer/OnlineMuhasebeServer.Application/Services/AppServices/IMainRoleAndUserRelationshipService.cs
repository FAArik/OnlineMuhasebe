
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppServices;

public interface IMainRoleAndUserRelationshipService
{
    Task CreateAsync(MainRoleAndUserRelationship mainRoleAndUserRelationship,CancellationToken cancellationToken);
    Task RemoveById(string Id);
    Task<MainRoleAndUserRelationship> GetByUserIdAndCompanyIdAndMAinRoleIdAsync(string UserId,string CompanyId,string MainRoleId,CancellationToken cancellationToken);
    Task<MainRoleAndUserRelationship> GetByIdAsync(string id,bool isTracking);
    Task<MainRoleAndUserRelationship> GetRolesByUserIdAndCompanyId(string userId, string companyId);
}
