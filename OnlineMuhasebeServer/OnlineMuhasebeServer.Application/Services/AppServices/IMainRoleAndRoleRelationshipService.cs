
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppServices;

public interface IMainRoleAndRoleRelationshipService
{
    Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship,CancellationToken cancellationToken);
    Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship);
    Task RemoveByIdAsync(string Id);
    IQueryable<MainRoleAndRoleRelationship>GetAll();
    Task<MainRoleAndRoleRelationship> GetByIdAsync(string Id);
    Task<MainRoleAndRoleRelationship> GetFirsByRoleIdAndMainRoleId(string roleId,string mainRoleId,CancellationToken cancellationToken);
    Task<IList<MainRoleAndRoleRelationship>> GetByListByMainRoleIdForGetRolesAsync(string Id);
    

}
