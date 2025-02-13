﻿using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Queries.GetAllReport;

public sealed record GetAllReportQuery(

    string CompanyId,
    int pageNumber = 1,
    int pageSize = 5) : IQuery<GetAllReportQueryResponse>;
