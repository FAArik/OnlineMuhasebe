using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRl;

public sealed class RemoveByIdMainRoleAndRoleRlCommandHandler : ICommandHandler<RemoveByIdMainRoleAndRoleRlCommand, RemoveByIdMainRoleAndRoleRlCommandResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _roleService;

    public RemoveByIdMainRoleAndRoleRlCommandHandler(IMainRoleAndRoleRelationshipService roleService)
    {
        _roleService = roleService;
    }

    public async Task<RemoveByIdMainRoleAndRoleRlCommandResponse> Handle(RemoveByIdMainRoleAndRoleRlCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationship entity = await _roleService.GetByIdAsync(request.Id);
        if (entity == null) throw new Exception("Belirtilen ana rol ve rol bağlantısı bulunamadı!");

        await _roleService.RemoveByIdAsync(request.Id);
        return new();
    }
}
