using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRl;

public sealed class CreateMainRoleAndRlCommandHandler : ICommandHandler<CreateMainRoleAndRlCommand, CreateMainRoleAndRlCommandResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _mRARRService;

    public CreateMainRoleAndRlCommandHandler(IMainRoleAndRoleRelationshipService mRARRService)
    {
        _mRARRService = mRARRService;
    }

    public async Task<CreateMainRoleAndRlCommandResponse> Handle(CreateMainRoleAndRlCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndRoleRelationship checkRoleAndMainRoleIsRelated = await _mRARRService.GetFirsByRoleIdAndMainRoleId(request.RoleId, request.MainRoleId, cancellationToken);
        if (checkRoleAndMainRoleIsRelated != null) throw new Exception("Bu rol ilişkisi daha önce kurulmuş!");

        MainRoleAndRoleRelationship mainRoleAndRoleRelationship = new(
            Guid.NewGuid().ToString(),
            request.RoleId,
            request.MainRoleId);

        await _mRARRService.CreateAsync(mainRoleAndRoleRelationship, cancellationToken);
        return new();
    }
}
