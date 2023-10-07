﻿using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRl;

public sealed record CreateMainRoleAndRlCommand(string RoleId,string MainRoleId):ICommand<CreateMainRoleAndRlCommandResponse>;

