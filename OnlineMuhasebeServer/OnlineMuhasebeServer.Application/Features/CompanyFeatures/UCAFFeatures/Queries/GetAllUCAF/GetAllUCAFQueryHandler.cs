﻿using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.CompanyService;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Queries.GetAllUCAF;

public sealed class GetAllUCAFQueryHandler : IQueryHandler<GetAllUCAFQuery, GetAllUCAFQueryResponse>
{
    private readonly IUCAFService _ucafService;

    public GetAllUCAFQueryHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public async Task<GetAllUCAFQueryResponse> Handle(GetAllUCAFQuery request, CancellationToken cancellationToken)
     {
        return new(await _ucafService.GetAllAsync(request.companyId));
    }
}
