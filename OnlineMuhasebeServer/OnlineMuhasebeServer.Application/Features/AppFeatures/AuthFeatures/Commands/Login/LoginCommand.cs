﻿using OnlineMuhasebeServer.Application.Features.AppFeatures.AutvschFeatures.Commands.Login;
using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public sealed record LoginCommand(string EmailOrUserName, string Password) : ICommand<LoginCommandResponse>;
}
