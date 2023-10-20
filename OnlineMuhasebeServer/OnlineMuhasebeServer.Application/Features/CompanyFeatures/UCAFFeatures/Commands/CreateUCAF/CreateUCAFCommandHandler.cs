using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed class CreateUCAFCommandHandler : ICommandHandler<CreateUCAFCommand, CreateUCAFCommandResponse>
    {
        private readonly IUCAFService _ucafService;
        private readonly ILogService _logService;
        private readonly IApiService _apiservice;

        public CreateUCAFCommandHandler(IUCAFService ucafService, ILogService logService, IApiService apiservice)
        {
            _ucafService = ucafService;
            _logService = logService;
            _apiservice = apiservice;
        }

        public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommand request, CancellationToken cancellationToken)
        {
            if (request.Type != "G" && request.Type != "M") throw new Exception("Hesap planı türü Grup yada Muavin olmalıdır.");

            UniformChartOfAccount ucaf = await _ucafService.GetByCodeAsync(request.CompanyId, request.Code, cancellationToken);
            if (ucaf != null) throw new Exception("Bu hesap planı kodu daha önce tanımlanmış");

            UniformChartOfAccount ucafret= await _ucafService.CreateUcafAsync(request, cancellationToken);
            string userId = _apiservice.GetUserIdByToken();
            Log log = new()
            {
                Id = Guid.NewGuid().ToString(),
                TableName = nameof(UniformChartOfAccount),
                Progress = "Create",
                UserId = userId,
                Data = JsonConvert.SerializeObject(ucafret)
            };
            await _logService.AddAsync(log,request.CompanyId);
            return new();
        }
    }
}
