using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;

public sealed class UpdateUCAFCommandHandler : ICommandHandler<UpdateUCAFCommand, UpdateUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;
    private readonly ILogService _logService;
    private readonly IApiService _apiservice;

    public UpdateUCAFCommandHandler(IUCAFService ucafService, ILogService logService, IApiService apiservice)
    {
        _ucafService = ucafService;
        _logService = logService;
        _apiservice = apiservice;
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
        string userId = _apiservice.GetUserIdByToken();
        Log oldLog = new()
        {
            Id = Guid.NewGuid().ToString(),
            Progress = "BeforeUpdate",
            TableName = nameof(UniformChartOfAccount),
            Data = JsonConvert.SerializeObject(checkucaf),
            UserId = userId
        };

        if (request.Type != "G" && request.Type != "M") throw new Exception("Hesap planı türü Grup yada Muavin olmalıdır!");

        checkucaf.Type = request.Type == "G" ? 'G' : 'M';
        checkucaf.Code = request.Code;
        checkucaf.Name = request.Name;

        await _ucafService.UpdateAsync(checkucaf, request.CompanyId);
        Log NewLog = new()
        {
            Id = Guid.NewGuid().ToString(),
            Progress = "AfterUpdate",
            TableName = nameof(UniformChartOfAccount),
            Data = JsonConvert.SerializeObject(checkucaf),
            UserId = userId
        };
        await _logService.AddAsync(oldLog, request.CompanyId);
        await _logService.AddAsync(NewLog, request.CompanyId);

        return new();
    }
}
