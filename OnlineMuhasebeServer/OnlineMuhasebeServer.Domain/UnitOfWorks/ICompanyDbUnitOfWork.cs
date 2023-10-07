using Microsoft.EntityFrameworkCore;

namespace OnlineMuhasebeServer.Domain.UnitOfWorks;

public interface ICompanyDbUnitOfWork : IUnitOfWork
{
    void SetDbContexInstance(DbContext context);
}
