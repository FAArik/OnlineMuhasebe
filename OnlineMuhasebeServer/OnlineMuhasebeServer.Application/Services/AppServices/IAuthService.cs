using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Application.Services.AppServices;

public interface IAuthService
{
    Task<AppUser> GetByEmailOrUserNameAsync(string EmailOrUserName);
    Task<bool> CheckPasswordAsync(AppUser user, string password);
    Task<IList<UserAndCompanyRelationship>> GetCompanyListByUserIdAsync(string Id);
    Task<IList<string>> GetRolesByUserIdAndCompanyId(string userId,string companyId);
}
