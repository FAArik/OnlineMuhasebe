using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.RemoveByIdUserAndCompanyRl;

public sealed class RemoveByIdUserAndCompanyRlCommandHandler : ICommandHandler<RemoveByIdUserAndCompanyRlCommand, RemoveByIdUserAndCompanyRlCommandResponse>
{
    private readonly IUserAndCompanyRelationshipService _service;

    public RemoveByIdUserAndCompanyRlCommandHandler(IUserAndCompanyRelationshipService service)
    {
        _service = service;
    }

    public async Task<RemoveByIdUserAndCompanyRlCommandResponse> Handle(RemoveByIdUserAndCompanyRlCommand request, CancellationToken cancellationToken)
    {
        await _service.RemoveByIdAsync(request.Id);
        return new();
    }
}
