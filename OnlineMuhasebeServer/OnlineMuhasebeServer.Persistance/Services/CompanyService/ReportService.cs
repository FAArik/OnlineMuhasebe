using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.CompanyEntities;
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

    public ReportService(IContextService contextService, IReportCommandRepository reportCommandRepository, IReportQueryRepository reportQueryRepository, ICompanyDbUnitOfWork unitOfWork)
    {
        _contextService = contextService;
        _reportCommandRepository = reportCommandRepository;
        _reportQueryRepository = reportQueryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IList<Report>> GetAllReportsByCompanyId(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _reportQueryRepository.SetDbContexInstance(_context);
        return await _reportQueryRepository.GetAll(false).OrderByDescending(x => x.CreatedDate).ToListAsync();
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

    }
}
