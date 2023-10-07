using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateStaticMainRoles;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Queries.GetAllMainRole;
using OnlineMuhasebeServer.Presentation.Abstraction;

namespace OnlineMuhasebeServer.Presentation.Controller;

public sealed class MainRoleController : ApiController
{
    public MainRoleController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleCommand request,CancellationToken cancellation)
    {
        CreateMainRoleCommandResponse response = await _mediator.Send(request, cancellation);
        return Ok(response);

    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateStaticMainroles(CancellationToken cancellation)
    {
        CreateStaticMainRolesCommand request = new();
        CreateStaticMainRolesCommandResponse response = await _mediator.Send(request, cancellation);
        return Ok(response);

    }
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllMainRoleQuery request)
    {
        GetAllMainRoleQueryResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveById(RemoveByIdMainRoleCommand request)
    {
        RemoveByIdMainRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);

    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateMainRoleCommand request)
    {
        UpdateMainRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);

    }
}
