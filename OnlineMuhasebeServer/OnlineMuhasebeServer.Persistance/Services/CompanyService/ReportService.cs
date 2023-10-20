using EntityFrameworkCorePagination.Nuget.Pagination;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.ReportRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.ComparyService;

public class ReportService : IReportService
{
    private CompanyDbContext _context;
    private readonly IContextService _contextService;
    private readonly IReportCommandRepository _reportCommandRepository;
    private readonly IReportQueryRepository _reportQueryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IRabbitMQService _rabbitMQService;

    public ReportService(IContextService contextService, IReportCommandRepository reportCommandRepository, IReportQueryRepository reportQueryRepository, ICompanyDbUnitOfWork unitOfWork, IRabbitMQService rabbitMQService)
    {
        _contextService = contextService;
        _reportCommandRepository = reportCommandRepository;
        _reportQueryRepository = reportQueryRepository;
        _unitOfWork = unitOfWork;
        _rabbitMQService = rabbitMQService;
    }

    public async Task<PaginationResult<Report>> GetAllReportsByCompanyId(string companyId, int pageNumber = 1, int pageSize = 5)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _reportQueryRepository.SetDbContexInstance(_context);
        var result = await _reportQueryRepository.GetAll().OrderByDescending(x => x.CreatedDate).ToPagedListAsync(pageNumber,pageSize);
        return result;
    }

    public async Task Request(RequestReportCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _reportCommandRepository.SetDbContexInstance(_context);
        _unitOfWork.SetDbContexInstance(_context);

        Report report = new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Status = false

        };

        await _reportCommandRepository.AddAsync(report, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        SendQueue(report, request.CompanyId);
    }

    public void SendQueue(Report report, string companyId)
    {
        ReportDto reportDto = new()
        {
            Id = report.Id,
            Name = report.Name,
            CompanyId = companyId
        };
        _rabbitMQService.SendQueue(reportDto);
    }

}
