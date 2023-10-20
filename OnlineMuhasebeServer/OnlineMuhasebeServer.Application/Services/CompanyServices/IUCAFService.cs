using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Domain.CompanyEntities;

namespace OnlineMuhasebeServer.Application.Services.CompanyService;

public interface IUCAFService
{
    Task<UniformChartOfAccount> CreateUcafAsync(CreateUCAFCommand request, CancellationToken cancellationToken);
    Task<UniformChartOfAccount> GetByCodeAsync(string companyId, string Code, CancellationToken cancellationToken);
    Task CreateCompanyMainUcafsToCompanyAsync(string companyId, CancellationToken cancellationToken);
    Task<IList<UniformChartOfAccount>> GetAllAsync(string companyId);
    Task<UniformChartOfAccount>RemoveByIdUcafAsync(string Id, string companyId);
    Task<bool> CheckRemoveByIdGroupAndAvailable(string Id, string companyId);
    Task<UniformChartOfAccount> GetByIdAsync(string Id, string companyId);
    Task UpdateAsync(UniformChartOfAccount account, string companyId);
}
