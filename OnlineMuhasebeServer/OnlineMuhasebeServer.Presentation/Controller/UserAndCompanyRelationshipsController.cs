using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.CreateUserAndCompanyRl;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.RemoveByIdUserAndCompanyRl;
using OnlineMuhasebeServer.Presentation.Abstraction; 

namespace OnlineMuhasebeServer.Presentation.Controller;

public class UserAndCompanyRelationshipsController : ApiController
{
    public UserAndCompanyRelationshipsController(IMediator mediator) : base(mediator) {}


    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserAndCompanyRlCommand request,CancellationToken cancellationToken)
    {
        CreateUserAndCompanyRlCommandResponse response = await _mediator.Send(request,cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveById(RemoveByIdUserAndCompanyRlCommand request)
    {
        RemoveByIdUserAndCompanyRlCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }
}
