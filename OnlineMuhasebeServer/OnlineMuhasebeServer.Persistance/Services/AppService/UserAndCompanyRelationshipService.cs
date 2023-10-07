using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.UserAndCompanyRelationshipRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;

namespace OnlineMuhasebeServer.Persistance.Services.AppService;

public class UserAndCompanyRelationshipService : IUserAndCompanyRelationshipService
{
    private readonly IUserAndCompanyRelationshipCommandRepository _commandRepository;
    private readonly IUserAndCompanyRelationshipQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitOfWork;

    public UserAndCompanyRelationshipService(IUserAndCompanyRelationshipCommandRepository commandRepository, IUserAndCompanyRelationshipQueryRepository queryRepository, IAppUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(UserAndCompanyRelationship userAndCompanyRelationship, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(userAndCompanyRelationship, cancellationToken);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<UserAndCompanyRelationship> GetByIdAsync(string Id)
    {
        return await _queryRepository.GetById(Id);
    }

    public async Task<UserAndCompanyRelationship> GetByUserIdAndCompanyId(string UserId, string CompanyId, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(x => x.AppUserID == UserId && x.CompanyId == CompanyId, cancellationToken);
    }

    public async Task<IList<UserAndCompanyRelationship>> GetListByUserId(string UserId)
    {
        return await _queryRepository.GetWhere(x => x.AppUserID == UserId).Include("Company").ToListAsync() ;
    }

    public async Task RemoveByIdAsync(string Id)
    {
        await _commandRepository.RemoveById(Id);
        await _unitOfWork.SaveChangesAsync();
    }
}
