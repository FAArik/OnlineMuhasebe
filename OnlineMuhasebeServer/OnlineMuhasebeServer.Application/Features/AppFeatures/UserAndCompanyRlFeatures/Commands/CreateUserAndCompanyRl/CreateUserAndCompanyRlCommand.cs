﻿using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.CreateUserAndCompanyRl;

public sealed record CreateUserAndCompanyRlCommand(string UserId, string CompanyId):ICommand<CreateUserAndCompanyRlCommandResponse>;
