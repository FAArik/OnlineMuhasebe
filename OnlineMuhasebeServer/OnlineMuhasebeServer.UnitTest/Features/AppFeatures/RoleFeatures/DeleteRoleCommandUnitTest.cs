using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures;


public sealed class DeleteRoleCommandUnitTest
{
    private readonly Mock<IRoleService> _roleService;

    public DeleteRoleCommandUnitTest()
    {
        _roleService = new();
    }

    [Fact]
    public async Task AppRoleShouldNotBeNull()
    {
        _roleService.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(new AppRole());
    }
    [Fact]
    public async Task DeleteRoleCommandResponseShouldNotBeNull()
    {
        var command = new DeleteRoleCommand(
            Id: "0c0bb3c5-6162-458e-abd1-3b423f674b05");

        var handler = new DeleteRoleCommandHandler(_roleService.Object);
        _roleService.Setup(x => x.GetById(It.IsAny<string>())).ReturnsAsync(new AppRole());
        DeleteRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();

    }
}
