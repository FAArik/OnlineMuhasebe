﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Commands.GetTokenByRefreshToken;
using OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Commands.Login;
using OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Queries.GetRolesByUserIdAndCompanyId;
using OnlineMuhasebeServer.Application.Features.AppFeatures.AutvschFeatures.Commands.Login;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginCommand request)
        {
            LoginCommandResponse respnse = await _mediator.Send(request);
            return Ok(respnse);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetTokenByRefreshToken(GetTokenByRefreshTokenCommand request)
        {
            GetTokenByRefreshTokenCommandResponse respnse = await _mediator.Send(request);
            return Ok(respnse);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetRolesByUserIdAndCompanyId(GetRolesByUserIdAndCompanyIdQuery request)
        {
            GetRolesByUserIdAndCompanyIdQueryResponse respnse = await _mediator.Send(request);
            return Ok(respnse);
        }
    }
    
}
