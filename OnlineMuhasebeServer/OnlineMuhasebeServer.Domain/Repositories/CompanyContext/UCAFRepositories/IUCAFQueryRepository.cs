using OnlineMuhasebeServer.Domain.CompanyEntities;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.CompanyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.Repositories.CompanyContext.UCAFRepositories
{
    public interface IUCAFQueryRepository : ICompanyQueryRepository<UniformChartOfAccount>
    {
    }
}
