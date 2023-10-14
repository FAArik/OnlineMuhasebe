using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;

public sealed class UpdateUCAFCommandHandler : ICommandHandler<UpdateUCAFCommand, UpdateUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;

    public UpdateUCAFCommandHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public Task<UpdateUCAFCommandResponse> Handle(UpdateUCAFCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
