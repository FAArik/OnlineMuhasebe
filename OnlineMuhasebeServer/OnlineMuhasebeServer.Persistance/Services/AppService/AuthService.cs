using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Persistance.Services.AppService;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserAndCompanyRelationshipService _uAndCRLService;
    private readonly IMainRoleAndUserRelationshipService _mRAndURLService;
    private readonly IMainRoleAndRoleRelationshipService _mainRoleAndRoleRlService;

    public AuthService(UserManager<AppUser> userManager, IUserAndCompanyRelationshipService uAndCRLService, IMainRoleAndUserRelationshipService mRAndURLService, IMainRoleAndRoleRelationshipService MainRoleAndRoleRlService)
    {
        _userManager = userManager;
        _uAndCRLService = uAndCRLService;
        _mRAndURLService = mRAndURLService;
        _mainRoleAndRoleRlService = MainRoleAndRoleRlService;
    }

    public async Task<bool> CheckPasswordAsync(AppUser user, string password)
    {
        
        return await _userManager.CheckPasswordAsync(user,password);
        
    }

    public async Task<AppUser> GetByEmailOrUserNameAsync(string EmailOrUserName)
    {
        return await _userManager.Users.Where(x => x.Email == EmailOrUserName || x.UserName == EmailOrUserName).FirstOrDefaultAsync();
    }

    public async Task<IList<UserAndCompanyRelationship>> GetCompanyListByUserIdAsync(string Id)
    {
        return await _uAndCRLService.GetListByUserId(Id);
    }

    public async Task<IList<string>> GetRolesByUserIdAndCompanyId(string userId, string companyId)
    {
        MainRoleAndUserRelationship mainRoleAndUserRelationship= await _mRAndURLService.GetRolesByUserIdAndCompanyId(userId, companyId);

        IList<MainRoleAndRoleRelationship> getMainRoles = await _mainRoleAndRoleRlService.GetByListByMainRoleIdForGetRolesAsync(mainRoleAndUserRelationship.MainRoleId);

        IList<string> roles = getMainRoles.Select(s => s.AppRole.Name).ToList();

        return roles;
    }
}
