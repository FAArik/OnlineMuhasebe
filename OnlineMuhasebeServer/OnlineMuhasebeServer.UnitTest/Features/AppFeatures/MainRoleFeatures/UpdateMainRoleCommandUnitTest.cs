using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleFeatures;

public sealed class UpdateMainRoleCommandUnitTest
{
    private readonly Mock<IMainRoleService> _mainRoleService;

    public UpdateMainRoleCommandUnitTest()
    {
        _mainRoleService = new();
    }
    [Fact]
    public async Task MainRoleShouldNotBeNull()
    {
         _mainRoleService.Setup(x=>x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new MainRole());
    }
    [Fact]
    public async Task UpdateMainRoleCommandResponseShouldNotBeNull()
    {
        var command = new  UpdateMainRoleCommand(Title: "Admin", Id: "8079e659-d3be-404a-abe1-b4d8e08a281b");
        var handler = new UpdateMainRoleCommandHandler(_mainRoleService.Object);

        _mainRoleService.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new MainRole());

        UpdateMainRoleCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeNull();
    }
}
