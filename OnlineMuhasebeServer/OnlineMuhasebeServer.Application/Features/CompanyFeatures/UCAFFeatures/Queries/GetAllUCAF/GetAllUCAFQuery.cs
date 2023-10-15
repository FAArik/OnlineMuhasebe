using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Queries.GetAllUCAF;

public sealed record GetAllUCAFQuery(string companyId) :IQuery<GetAllUCAFQueryResponse>;
