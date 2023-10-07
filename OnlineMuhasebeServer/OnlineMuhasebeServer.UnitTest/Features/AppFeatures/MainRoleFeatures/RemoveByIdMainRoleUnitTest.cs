using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleFeatures;

public sealed class RemoveByIdMainRoleUnitTest
{
    private readonly Mock<IMainRoleService> _mainRoleService;

    public RemoveByIdMainRoleUnitTest()
    {
        _mainRoleService = new();
    }
    [Fact]
    public async Task RemoveByIdMainRoleCommandShouldNotBeNull()
    {
        var command = new RemoveByIdMainRoleCommand( Id: "8079e659-d3be-404a-abe1-b4d8e08a281b");
        var handler = new RemoveByIdMainRoleCommandHandler(_mainRoleService.Object);
        RemoveByIdMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeNull();
    }

}
