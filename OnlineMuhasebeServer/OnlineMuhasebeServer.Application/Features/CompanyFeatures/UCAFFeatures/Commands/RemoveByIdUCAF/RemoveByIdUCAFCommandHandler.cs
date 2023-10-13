using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF;

public sealed class RemoveByIdUCAFCommandHandler : ICommandHandler<RemoveByIdUCAFCommand, RemoveByIdUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;

    public RemoveByIdUCAFCommandHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public async Task<RemoveByIdUCAFCommandResponse> Handle(RemoveByIdUCAFCommand request, CancellationToken cancellationToken)
    {
        var checkbyId = await _ucafService.CheckRemoveByIdGroupAndAvailable(request.Id, request.companyId);

        if (checkbyId == true) throw new Exception("Hesap planına bağlı alt hesaplar olduğundan silinemiyor!");

        await _ucafService.RemoveByIdUcafAsync(request.Id, request.companyId);
        return new();
    }
}
