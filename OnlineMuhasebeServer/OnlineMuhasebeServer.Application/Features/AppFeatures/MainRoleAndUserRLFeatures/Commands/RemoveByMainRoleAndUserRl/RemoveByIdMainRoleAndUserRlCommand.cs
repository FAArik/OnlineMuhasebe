﻿using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByMainRoleAndUserRl;

public sealed record RemoveByIdMainRoleAndUserRlCommand(string Id) : ICommand<RemoveByIdMainRoleAndUserRlCommandResponse>;