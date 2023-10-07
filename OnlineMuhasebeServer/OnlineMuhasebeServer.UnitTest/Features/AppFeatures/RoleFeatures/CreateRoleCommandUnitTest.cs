using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.RoleFeatures;

public sealed class CreateRoleCommandUnitTest
{
    private readonly Mock<IRoleService> _roleService;

    public CreateRoleCommandUnitTest()
    {
        _roleService = new();
    }

    [Fact]
    public async Task AppRoleShouldBeNull()
    {
        AppRole appRole = await _roleService.Object.GetByCode("UCAF_Create");
        appRole.ShouldBeNull();
    }
    [Fact]
    public async Task CreateRoleCommandResponseShouldNotBeNull()
    {
        var command = new CreateRoleCommand(Code: "UCAF.Create",
            Name: "Hesap Planı Kaydı Ekleme");

        var handler = new CreateRoleCommandHandler(_roleService.Object);
        {
            CreateRoleCommandResponse response = await handler.Handle(command, default);
            response.ShouldNotBeNull();
            response.Message.ShouldNotBeEmpty();
        }
    }
}
