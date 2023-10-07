using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByMainRoleAndUserRl;

public sealed class RemoveByIdMainRoleAndUserRlCommandHandler : ICommandHandler<RemoveByIdMainRoleAndUserRlCommand, RemoveByIdMainRoleAndUserRlCommandResponse>
{
    private readonly IMainRoleAndUserRelationshipService _service;

    public RemoveByIdMainRoleAndUserRlCommandHandler(IMainRoleAndUserRelationshipService service)
    {
        _service = service;
    }

    public async Task<RemoveByIdMainRoleAndUserRlCommandResponse> Handle(RemoveByIdMainRoleAndUserRlCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationship checkEntity = await _service.GetByIdAsync(request.Id,false);
        if (checkEntity == null) throw new Exception("Kullanıcı bu role zaten sahip değil!");

        await _service.RemoveById(request.Id);
        return new();
    }
}
