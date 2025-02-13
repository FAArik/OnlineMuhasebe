﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.UnitOfWorks;
using OnlineMuhasebeServer.Persistance.Context;

namespace OnlineMuhasebeServer.Persistance.UnitOfWorks;

public sealed class CompanyDbUnitOfWork : ICompanyDbUnitOfWork
{
    private CompanyDbContext _context;
    public void SetDbContexInstance(DbContext context)
    {
        _context = (CompanyDbContext)context;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
    {
        int count = await _context.SaveChangesAsync(cancellationToken);
        return count;
    }
}
