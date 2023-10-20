using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF;

public sealed class RemoveByIdUCAFCommandHandler : ICommandHandler<RemoveByIdUCAFCommand, RemoveByIdUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;
    private readonly ILogService _logService;
    private readonly IApiService _apiservice;

    public RemoveByIdUCAFCommandHandler(IUCAFService ucafService, ILogService logService, IApiService apiservice)
    {
        _ucafService = ucafService;
        _logService = logService;
        _apiservice = apiservice;
    }

    public async Task<RemoveByIdUCAFCommandResponse> Handle(RemoveByIdUCAFCommand request, CancellationToken cancellationToken)
    {
        var checkbyId = await _ucafService.CheckRemoveByIdGroupAndAvailable(request.Id, request.companyId);

        if (checkbyId == false) throw new Exception("Hesap planına bağlı alt hesaplar olduğundan silinemiyor!");

        
        UniformChartOfAccount ucaf = await _ucafService.RemoveByIdUcafAsync(request.Id, request.companyId);

        string userId = _apiservice.GetUserIdByToken();
        Log log = new Log()
        {
            Id = Guid.NewGuid().ToString(),
            TableName = nameof(UniformChartOfAccount),
            Progress = "Delete",
            Data = JsonConvert.SerializeObject(ucaf),
            UserId = userId
        };
        await _logService.AddAsync(log, request.companyId);
        return new();
    }
}
