using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Queries.GetAllMainroleAndRoleRL;

public sealed class GetAllMainRoleAndRoleRlQueryHandler : IQueryHandler<GetAllMainRoleAndRoleRlQuery, GetAllMainRoleAndRoleRlQueryResponse>
{
    private readonly IMainRoleAndRoleRelationshipService _roleRelationshipService;

    public GetAllMainRoleAndRoleRlQueryHandler(IMainRoleAndRoleRelationshipService roleRelationshipService)
    {
        _roleRelationshipService = roleRelationshipService;
    }

    public async Task<GetAllMainRoleAndRoleRlQueryResponse> Handle(GetAllMainRoleAndRoleRlQuery request, CancellationToken cancellationToken)
    {
        return new(await _roleRelationshipService.GetAll().Include("AppRole").Include("MainRole").ToListAsync());
    }
}
