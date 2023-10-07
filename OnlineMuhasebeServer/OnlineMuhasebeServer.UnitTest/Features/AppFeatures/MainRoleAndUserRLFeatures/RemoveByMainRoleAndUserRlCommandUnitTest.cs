using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByMainRoleAndUserRl;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndUserRLFeatures;

public sealed class RemoveByMainRoleAndUserRlCommandUnitTest
{
    private readonly Mock<IMainRoleAndUserRelationshipService> _service;

    public RemoveByMainRoleAndUserRlCommandUnitTest()
    {
        _service = new();
    }

    [Fact]
    public async Task MainRoleAndUserRelationshipShouldNotBeNull()
    {
        _service.Setup(x => x.GetByIdAsync(It.IsAny<string>(),false)).ReturnsAsync(new MainRoleAndUserRelationship());

    }
    [Fact]
    public async Task RemoveByIdMainRoleAndUserRelationshipCommandShouldNotBeNull()
    {
        RemoveByIdMainRoleAndUserRlCommand command = new(
            Id: "72925bc9-61cf-4e57-9d57-faea50cf08a7"
            );

        RemoveByIdMainRoleAndUserRlCommandHandler handler = new(_service.Object);
        _service.Setup(x => x.GetByIdAsync(It.IsAny<string>(), false)).ReturnsAsync(new MainRoleAndUserRelationship());

        RemoveByIdMainRoleAndUserRlCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();

    }
}
