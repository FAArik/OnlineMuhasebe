using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRl;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndRoleRLFeatures;

public sealed class RemoveByIdMainRoleAndRoleRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndRoleRelationshipService> _service;

    public RemoveByIdMainRoleAndRoleRLCommandUnitTest()
    {
        _service = new();
    }
    [Fact]
    public async Task RemoveByIdMainRoleAndRoleRLShouldNotBeNull()
    {
        _service.Setup(s=>s.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new MainRoleAndRoleRelationship());

    }

    [Fact] 
    public async Task RemoveByIdMainRoleAndRoleRLCommandResponseShouldNotBeNull()
    {
        RemoveByIdMainRoleAndRoleRlCommand command = new(Id:"D5E7A0C7-0DAB-4340-B3CB-6A80B9A3AC4B");
        RemoveByIdMainRoleAndRoleRlCommandHandler handler = new(_service.Object);
        _service.Setup(s => s.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new MainRoleAndRoleRelationship());
        RemoveByIdMainRoleAndRoleRlCommandResponse response= await handler.Handle(command,default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }

}
