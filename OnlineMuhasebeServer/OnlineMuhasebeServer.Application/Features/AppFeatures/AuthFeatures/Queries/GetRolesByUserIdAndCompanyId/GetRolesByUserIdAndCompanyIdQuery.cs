﻿using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Queries.GetRolesByUserIdAndCompanyId;

public sealed record GetRolesByUserIdAndCompanyIdQuery(string userId,string companyId):IQuery<GetRolesByUserIdAndCompanyIdQueryResponse>;

