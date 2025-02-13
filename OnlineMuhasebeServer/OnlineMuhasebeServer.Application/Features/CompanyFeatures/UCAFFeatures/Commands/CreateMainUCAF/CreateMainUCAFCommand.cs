﻿using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateMainUCAF;

public sealed record CreateMainUCAFCommand(string companyId) : ICommand<CreateMainUCAFCommandResponse>;
