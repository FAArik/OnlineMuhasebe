﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.Repositories.GenericRepositories.AppDbContext;
using System.Linq.Expressions;

namespace OnlineMuhasebeServer.Persistance.Repositories.GenericRepositories.AppDbContext;

public class AppQueryRepository<T> : IAppQueryRepository<T> where T : Entity
{
    private static readonly Func<Context.AppDbContext, string, bool, Task<T>> GetByIdCompiled = 
        EF.CompileAsyncQuery((Context.AppDbContext context, string id,bool isTracking) => context.Set<T>().FirstOrDefault(p => p.Id == id));
    private static readonly Func<Context.AppDbContext, bool, Task<T>> GetFirstCompiled = EF.CompileAsyncQuery((Context.AppDbContext context, bool isTracking) => isTracking == true ? context.Set<T>().FirstOrDefault() : context.Set<T>().AsNoTracking().FirstOrDefault());
    
    private Context.AppDbContext _context;
    public DbSet<T> Entity { get; set; }
    public AppQueryRepository(Context.AppDbContext context)
    {
        _context = context;
        Entity = _context.Set<T>();
    }
    public IQueryable<T> GetAll(bool isTracking = true)
    {
        var result = Entity.AsQueryable();
        if (!isTracking)
        {
            result = Entity.AsNoTracking();
        }
        return result;
    }

    public async Task<T> GetById(string Id, bool isTracking = true)
    {
        return await GetByIdCompiled(_context, Id, isTracking);
    }

    public async Task<T> GetFirst(bool isTracking = true)
    {
        return await GetFirstCompiled(_context, isTracking);
    }

    public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, CancellationToken cancellationToken , bool isTracking = true)
    {
        T entity = null;
        if (!isTracking)
        {
             entity =await Entity.AsNoTracking().FirstOrDefaultAsync(expression,cancellationToken);
        }
        else
        {
            entity= await Entity.FirstOrDefaultAsync(expression,cancellationToken);
        }
        return entity;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
    {
        var result = Entity.Where(expression);
        if (!isTracking)
        {
            result = Entity.AsNoTracking();
        }
        return result;
    }

}
