using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRl;

public sealed class CreateMainRoleAndUserRlCommandHandler : ICommandHandler<RemoveByIdMainRoleAndUserRelationshipCommand, CreateMainRoleAndUserRlCommandResponse>
{
    private readonly IMainRoleAndUserRelationshipService _service;

    public CreateMainRoleAndUserRlCommandHandler(IMainRoleAndUserRelationshipService service)
    {
        _service = service;
    }

    public async Task<CreateMainRoleAndUserRlCommandResponse> Handle(RemoveByIdMainRoleAndUserRelationshipCommand request, CancellationToken cancellationToken)
    {
        MainRoleAndUserRelationship checkEntity = await _service.GetByUserIdAndCompanyIdAndMAinRoleIdAsync(request.UserId, request.CompanyId, request.MainRoleId, cancellationToken);
        if (checkEntity != null) throw new Exception("Kullanıcı bu role zaten sahip!");
        MainRoleAndUserRelationship mainRoleAndUserRelationship = new(
            Guid.NewGuid().ToString(),
            request.UserId, request.CompanyId, request.MainRoleId);
        await _service.CreateAsync(mainRoleAndUserRelationship,cancellationToken);
        return new();
    }
}
