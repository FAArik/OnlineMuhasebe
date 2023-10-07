using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.CompanyRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.Services.AppService;

public sealed class CompanyService : ICompanyService
{
    private readonly ICompanyDbCommandRepository _companyDbCommandRepository;
    private readonly ICompanyDbQueryRepository _companyDbQueryRepository;
    private readonly IAppUnitOfWork _unitOfWork;


    private readonly IMapper _mapper;

    public CompanyService(IMapper mapper, ICompanyDbCommandRepository companyDbCommandRepository, ICompanyDbQueryRepository companyDbQueryRepository, IAppUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _companyDbCommandRepository = companyDbCommandRepository;
        _companyDbQueryRepository = companyDbQueryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateCompany(CreateCompanyCommand request,CancellationToken cancellationToken)
    {
        Company company = _mapper.Map<Company>(request);
        company.Id = Guid.NewGuid().ToString();
        await _companyDbCommandRepository.AddAsync(company, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<Company> GetAll()
    {
        return _companyDbQueryRepository.GetAll();
    }

    public async Task<Company?> GetCompanyByName(string name,CancellationToken cancellationToken)
    {
        return await _companyDbQueryRepository.GetFirstByExpression(p=>p.Name==name, cancellationToken);
    }

    public async Task MigrateCompanyDatabases()
    {
        var companies = await _companyDbQueryRepository.GetAll().ToListAsync();
        foreach (var company in companies)
        {
            var db = new CompanyDbContext(company);
            db.Database.Migrate();
        }
    }
}
