using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;

public sealed class UpdateUCAFCommandHandler : ICommandHandler<UpdateUCAFCommand, UpdateUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;

    public UpdateUCAFCommandHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public async Task<UpdateUCAFCommandResponse> Handle(UpdateUCAFCommand request, CancellationToken cancellationToken)
    {
        UniformChartOfAccount checkucaf = await _ucafService.GetByIdAsync(request.Id, request.CompanyId);
        if (checkucaf == null) throw new Exception("Hesap planı bulunamadı!");

        if (checkucaf.Code != request.Code)
        {
            UniformChartOfAccount checkNewCode = await _ucafService.GetByCodeAsync(request.CompanyId, request.Code, cancellationToken);
            if (checkNewCode != null) throw new Exception("Bu hesap planı kodu daha önce kullanılmış!");
        }

        if (request.Type != "G" && request.Type != "M") throw new Exception("Hesap planı türü Grup yada Muavin olmalıdır!");

        checkucaf.Type = request.Type == "G" ? 'G' : 'M';
        checkucaf.Code = request.Code;
        checkucaf.Name = request.Name;

        await _ucafService.UpdateAsync(checkucaf, request.CompanyId);
        return new();
    }
}
