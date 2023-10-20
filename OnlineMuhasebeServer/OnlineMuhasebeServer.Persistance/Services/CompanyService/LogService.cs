using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.LogFeatures.Queries.GetLogsByTableName;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Dtos;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.LogRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.CompanyService;

public class LogService : ILogService
{
    private CompanyDbContext _context;
    private readonly IContextService _contextService;
    private readonly ILogCommandRepository _logCommandRepository;
    private readonly ILogQueryRepository _logQueryRepository;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;

    public LogService(IContextService contextService, ILogCommandRepository logCommandRepository, ILogQueryRepository logQueryRepository, ICompanyDbUnitOfWork unitOfWork, UserManager<AppUser> userManager)
    {
        _contextService = contextService;
        _logCommandRepository = logCommandRepository;
        _logQueryRepository = logQueryRepository;
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task AddAsync(Log log, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _logCommandRepository.SetDbContexInstance(_context);
        _unitOfWork.SetDbContexInstance(_context);

        await _logCommandRepository.AddAsync(log, default);
        await _unitOfWork.SaveChangesAsync();

    }

    public async Task<PaginationResult<LogDto>> GetAllByTableName(GetLogsByTableNameQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _logQueryRepository.SetDbContexInstance(_context);

        PaginationResult<Log> result = await _logQueryRepository.GetAll(false).Where(x=>x.TableName==request.TableName).OrderByDescending(x=>x.CreatedDate).ToPagedListAsync(request.pageNumber, request.pageSize);
        int count = _logQueryRepository.GetWhere(x=>x.TableName==request.TableName).Count();

        IList<LogDto> logdtos = new List<LogDto>();

        if (result.Datas != null)
        {
            foreach (var item in result.Datas)
            {
                AppUser user = await _userManager.FindByIdAsync(item.UserId);
                LogDto log = new()
                {
                    Id = item.Id,
                    CreateDate = item.CreatedDate,
                    Data = item.Data,
                    TableName = item.TableName,
                    UserId = item.UserId,
                    Progress=item.Progress,
                    UserEmail = user.Email,
                    UserName = user.NameLastName
                };
                logdtos.Add(log);
            }
        }

        PaginationResult<LogDto> requestResult = new(
             pageNumber: request.pageNumber,
            pageSize: request.pageSize,
            totalCount: count,
            datas: logdtos
            );

        return requestResult;

    }
}
