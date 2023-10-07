using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.MainRoleAndUserRelationshipRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;

namespace OnlineMuhasebeServer.Persistance.Services.AppService;

public class MainRoleAndUserRelationshipService : IMainRoleAndUserRelationshipService
{
    private readonly IMainRoleAndUserRelationshipCommandRepository _commandRepository;
    private readonly IMainRoleAndUserRelationshipQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public MainRoleAndUserRelationshipService(IMainRoleAndUserRelationshipQueryRepository queryRepository, IMainRoleAndUserRelationshipCommandRepository commandRepository, IAppUnitOfWork unitOfWork)
    {
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(MainRoleAndUserRelationship mainRoleAndUserRelationship,CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(mainRoleAndUserRelationship,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

    }

    public async Task<MainRoleAndUserRelationship> GetByIdAsync(string id,bool tracking)
    {
        return await _queryRepository.GetById(id,tracking);
    }

    public async Task<MainRoleAndUserRelationship> GetByUserIdAndCompanyIdAndMAinRoleIdAsync(string UserId, string CompanyId, string MainRoleId,CancellationToken cancellationToken)
    {
       return await _queryRepository.GetFirstByExpression(x=>x.UserId==UserId && x.CompanyId==x.CompanyId && x.MainRoleId==MainRoleId,cancellationToken);
    }

    public async Task<MainRoleAndUserRelationship> GetRolesByUserIdAndCompanyId(string userId, string companyId)
    {
        return await _queryRepository.GetFirstByExpression(x => x.UserId == userId && x.CompanyId == companyId,default);
    }

    public async Task RemoveById(string Id)
    {
        await _commandRepository.RemoveById(Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
