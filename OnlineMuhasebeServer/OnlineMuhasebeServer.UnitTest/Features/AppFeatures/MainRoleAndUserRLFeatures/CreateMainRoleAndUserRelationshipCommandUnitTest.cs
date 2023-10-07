using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRl;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRl;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndUserRLFeatures;


public class CreateMainRoleAndUserRelationshipCommandUnitTest
{
    private readonly Mock<IMainRoleAndUserRelationshipService> _service;

    public CreateMainRoleAndUserRelationshipCommandUnitTest()
    {
        _service = new();
    }
    [Fact]
    public async Task MainRoleAndUserRelationshipShouldBeNull()
    {
        MainRoleAndUserRelationship entity = await _service.Object.GetByUserIdAndCompanyIdAndMAinRoleIdAsync(
            UserId: "72925bc9-61cf-4e57-9d57-faea50cf08a7",
            CompanyId: "357311cb-2b69-4be1-984d-a305a347053e",
            MainRoleId: "7cd5c62f-12a9-425d-883a-27b0355df667", default);
        entity.ShouldBeNull();

    }
    [Fact]
    public async Task CreateMainRoleAndUserRelationshipCommandShouldNotBeNull()
    {
        RemoveByIdMainRoleAndUserRelationshipCommand command = new(
            UserId: "72925bc9-61cf-4e57-9d57-faea50cf08a7",
            MainRoleId: "7cd5c62f-12a9-425d-883a-27b0355df667",
            CompanyId: "357311cb-2b69-4be1-984d-a305a347053e"
            );

        CreateMainRoleAndUserRlCommandHandler handler = new(_service.Object);

        CreateMainRoleAndUserRlCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();

    }


}
