using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Roles;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;

public sealed class CreateStaticMainRolesCommandHandler : ICommandHandler<CreateStaticMainRolesCommand, CreateStaticMainRolesCommandResponse>
{
    private readonly IMainRoleService _mainRoleService;

    public CreateStaticMainRolesCommandHandler(IMainRoleService mainRoleService)
    {
        _mainRoleService = mainRoleService;
    }

    public async Task<CreateStaticMainRolesCommandResponse> Handle(CreateStaticMainRolesCommand request, CancellationToken cancellationToken)
    {
        List<MainRole> mainroles = RoleList.GetStaticMainRoles();
        List<MainRole> newMainRoles = new List<MainRole>();
        foreach (var mainrole in mainroles)
        {
            MainRole checkmainrole = await _mainRoleService.GetByTitleAndCompanyId(mainrole.Title,mainrole.CompanyId,cancellationToken);
            if (checkmainrole == null) newMainRoles.Add(mainrole);
        }
        await _mainRoleService.CreateRangeAsync(newMainRoles,cancellationToken);
        return new();
    }
}
