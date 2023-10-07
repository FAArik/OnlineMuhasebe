using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.MainRoleRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;

namespace OnlineMuhasebeServer.Persistance.Services.AppService;

public sealed class MainRoleService : IMainRoleService
{
    private readonly IMainRoleCommandRepository _mainRoleCommandRepository;
    private readonly IMainRoleQueryRepository _mainRoleQueryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleService(IMainRoleCommandRepository mainRoleCommandRepository, IMainRoleQueryRepository mainRoleQueryRepository, IAppUnitOfWork ıUnitOfWork)
    {
        _mainRoleCommandRepository = mainRoleCommandRepository;
        _mainRoleQueryRepository = mainRoleQueryRepository;
        _unitOfWork = ıUnitOfWork;
    }

    public async Task CreateAsync(MainRole mainRole,CancellationToken cancellation)
    {
        await _mainRoleCommandRepository.AddAsync(mainRole, cancellation);
        await _unitOfWork.SaveChangesAsync(cancellation);
    }

    public async Task CreateRangeAsync(List<MainRole> newMainRoles,CancellationToken cancellationToken)
    {
        await _mainRoleCommandRepository.AddRangeAsync(newMainRoles, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<MainRole> GetAll()
    {
        return _mainRoleQueryRepository.GetAll();
    }

    public async Task<MainRole> GetByIdAsync(string Id)
    {
        return await _mainRoleQueryRepository.GetById(Id);
    }
    public async Task<MainRole> GetByTitleAndCompanyId(string title, string companyId,CancellationToken cancellationToken)
    {
        //if (companyId == null) return await _mainRoleQueryRepository.GetFirstByExpression(p => p.Title == title, cancellationToken);

        return await _mainRoleQueryRepository.GetFirstByExpression(p => p.Title == title && p.CompanyId == companyId, cancellationToken,false);
    }

    public async Task RemoveByIdAsync(string Id)
    {
       await _mainRoleCommandRepository.RemoveById(Id);
       await _unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateAsync(MainRole mainRole)
    {
        _mainRoleCommandRepository.Update(mainRole);
        await _unitOfWork.SaveChangesAsync();
    }
}
