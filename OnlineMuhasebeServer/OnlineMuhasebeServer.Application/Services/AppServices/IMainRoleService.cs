﻿using OnlineMuhasebeServer.Domain.AppEntities;

namespace OnlineMuhasebeServer.Application.Services.AppServices;

public interface IMainRoleService
{
    Task<MainRole> GetByTitleAndCompanyId(string title, string companyId, CancellationToken cancellationToken);
    Task CreateAsync(MainRole mainRole, CancellationToken cancellationToken);
    Task CreateRangeAsync(List<MainRole> newMainRoles, CancellationToken cancellationToken);
    IQueryable<MainRole> GetAll();
    Task RemoveByIdAsync(string Id);
    Task<MainRole> GetByIdAsync(string Id);
    Task UpdateAsync(MainRole mainRole);

}
