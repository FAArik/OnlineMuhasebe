using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.CreateUserAndCompanyRl;

public sealed class CreateUserAndCompanyRlCommandHandler : ICommandHandler<CreateUserAndCompanyRlCommand, CreateUserAndCompanyRlCommandResponse>
{
    private readonly IUserAndCompanyRelationshipService _service;

    public CreateUserAndCompanyRlCommandHandler(IUserAndCompanyRelationshipService service)
    {
        _service = service;
    }

    public async Task<CreateUserAndCompanyRlCommandResponse> Handle(CreateUserAndCompanyRlCommand request, CancellationToken cancellationToken)
    {
        UserAndCompanyRelationship entity= await _service.GetByUserIdAndCompanyId(request.UserId, request.CompanyId, cancellationToken);
        if (entity != null) throw new Exception("Bu kullanıcı daha önce bu şirkete kayıt edilmiş!");
        UserAndCompanyRelationship userAndCompanyRelationship = new(Guid.NewGuid().ToString(),request.UserId,request.CompanyId) ;
        await _service.CreateAsync(userAndCompanyRelationship,cancellationToken);
        return new();
    }
}
