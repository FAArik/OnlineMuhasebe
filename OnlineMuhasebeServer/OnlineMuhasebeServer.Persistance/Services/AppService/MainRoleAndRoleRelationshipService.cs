using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.MainRoleAndRoleRelationshipRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;

namespace OnlineMuhasebeServer.Persistance.Services.AppService;

public class MainRoleAndRoleRelationshipService : IMainRoleAndRoleRelationshipService
{
    private readonly IMainRoleAndRoleRelationshipCommandRepository _commandRepository;
    private readonly IMainRoleAndRoleRelationshipQueryRepository _queryRepository;
    private readonly IAppUnitOfWork _unitofwork;

    public MainRoleAndRoleRelationshipService(IMainRoleAndRoleRelationshipCommandRepository commandRepository, IMainRoleAndRoleRelationshipQueryRepository queryRepository, IAppUnitOfWork unitofwork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitofwork = unitofwork;
    }

    public async Task CreateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship,CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(mainRoleAndRoleRelationship,cancellationToken);
        await _unitofwork.SaveChangesAsync();
    }

    public IQueryable<MainRoleAndRoleRelationship> GetAll()
    {
       return  _queryRepository.GetAll();
    }

    public async Task<MainRoleAndRoleRelationship> GetByIdAsync(string Id)
    {
        return await _queryRepository.GetById(Id);
    }

    public async Task<IList<MainRoleAndRoleRelationship>> GetByListByMainRoleIdForGetRolesAsync(string Id)
    {
        return await _queryRepository.GetWhere(x => x.MainRoleId == Id).Include("AppRole").ToListAsync();
    }

    public async Task<MainRoleAndRoleRelationship> GetFirsByRoleIdAndMainRoleId(string roleId, string mainRoleId ,CancellationToken cancellationToken)
    {
        return await _queryRepository.GetFirstByExpression(p => p.RoleId == roleId && p.MainRoleId == mainRoleId,cancellationToken);
    }

    public async Task RemoveByIdAsync(string Id)
    {
        await _commandRepository.RemoveById(Id);
        await _unitofwork.SaveChangesAsync();
    }

    public async Task UpdateAsync(MainRoleAndRoleRelationship mainRoleAndRoleRelationship)
    {
        _commandRepository.Update(mainRoleAndRoleRelationship);
        await _unitofwork.SaveChangesAsync();
    }
}
