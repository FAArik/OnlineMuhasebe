using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.CompanyRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.MainRoleAndRoleRelationshipRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.MainRoleAndUserRelationshipRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.MainRoleRepositories;
using OnlineMuhasebeServer.Domain.Repositories.AppContext.UserAndCompanyRelationshipRepositories;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.LogRepositories;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.ReportRepositories;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.UCAFRepositories;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance;
using OnlineMuhasebeServer.Persistance.Repositories.AppContext.CompanyRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.AppContext.MainRoleAndRoleRelationshipRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.AppContext.MainRoleAndUserRelationshipRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.AppContext.MainRoleRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.AppContext.UserAndCompanyRelationshipRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.CompanyContext.LogRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.CompanyContext.ReportRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.CompanyContext.UCAFRepositories;
using OnlineMuhasebeServer.Persistance.Services.AppService;
using OnlineMuhasebeServer.Persistance.Services.CompanyService;
using OnlineMuhasebeServer.Persistance.Services.ComparyService;
using OnlineMuhasebeServer.Persistance.UnitOfWorks;
using OnlineMuhasebeServer.Domain.Repositories.CompanyContext.BookEntryRepositories;
using OnlineMuhasebeServer.Persistance.Repositories.CompanyContext.BookEntryRepositories;
//UsingSpot

namespace OnlineMuhasebeServer.WebApi.Configurations;

public class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        #region Context UnitOfWork
        services.AddScoped<ICompanyDbUnitOfWork, CompanyDbUnitOfWork>();
        services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
        services.AddScoped<IContextService, ContextService>();
        #endregion

        #region Services
            #region CompanyDbContext
            services.AddScoped<IUCAFService, UCAFService>();
            services.AddScoped<IReportService, ReportService>();
                services.AddScoped<ILogService, LogService>();
                services.AddScoped<IBookEntryService, BookEntryService>();
            //CompanyServiceDISpot

            #endregion

            #region AppDbContext
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMainRoleService, MainRoleService>();
            services.AddScoped<IMainRoleAndRoleRelationshipService, MainRoleAndRoleRelationshipService>();
            services.AddScoped<IMainRoleAndUserRelationshipService, MainRoleAndUserRelationshipService>();
            services.AddScoped<IUserAndCompanyRelationshipService, UserAndCompanyRelationshipService>();
            //AppServiceDISpot
        #endregion
        #endregion

        #region Repositories
            #region CompanyDbContext
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            services.AddScoped<IReportCommandRepository, ReportCommandRepository>();
            services.AddScoped<IReportQueryRepository, ReportQueryRepository>();
            services.AddScoped<ILogCommandRepository, LogCommandRepository>();
            services.AddScoped<ILogQueryRepository, LogQueryRepository>();
                services.AddScoped<IBookEntryCommandRepository, BookEntryCommandRepository>();
                services.AddScoped<IBookEntryQueryRepository, BookEntryQueryRepository>();
            //CompanyRepositoryDISpot
        #endregion

            #region AppDbContext
        services.AddScoped<ICompanyDbCommandRepository, CompanyDbCommandRepository>();
            services.AddScoped<ICompanyDbQueryRepository, CompanyDbQueryRepository>();
            services.AddScoped<IMainRoleCommandRepository, MainRoleCommandRepository>();
            services.AddScoped<IMainRoleQueryRepository, MainRoleQueryRepository>();
            services.AddScoped<IMainRoleAndRoleRelationshipCommandRepository, MainRoleAndRoleRelationshipCommandRepository>();
            services.AddScoped<IMainRoleAndRoleRelationshipQueryRepository, MainRoleAndRoleRelationshipQueryRepository>();
            services.AddScoped<IMainRoleAndUserRelationshipCommandRepository, MainRoleAndUserRelationshipCommandRepository>();
            services.AddScoped<IMainRoleAndUserRelationshipQueryRepository, MainRoleAndUserRelationshipQueryRepository>();
            services.AddScoped<IUserAndCompanyRelationshipCommandRepository, UserAndCompanyRelationshipCommandRepository>();
            services.AddScoped<IUserAndCompanyRelationshipQueryRepository, UserAndCompanyRelationshipQueryRepository>();
            //AppRepositoryDISpot
            #endregion

        #endregion
    }

}
