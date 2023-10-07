﻿using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.RemoveByIdUserAndCompanyRl;

public sealed record RemoveByIdUserAndCompanyRlCommand(string Id) : ICommand<RemoveByIdUserAndCompanyRlCommandResponse>;

