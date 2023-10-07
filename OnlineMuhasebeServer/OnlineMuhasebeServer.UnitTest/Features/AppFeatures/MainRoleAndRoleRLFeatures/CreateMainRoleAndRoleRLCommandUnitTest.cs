using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRl;
using OnlineMuhasebeServer.Application.Services.AppService;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.MainRoleAndRoleRLFeatures;

public sealed class CreateMainRoleAndRoleRLCommandUnitTest
{
    private readonly Mock<IMainRoleAndRoleRelationshipService> _service;

    public CreateMainRoleAndRoleRLCommandUnitTest()
    {
        _service = new();
    }

    [Fact]
    public async Task MainRoleAndRoleRelationshipShouldBeNull()
    {
        MainRoleAndRoleRelationship relation = (await _service.Object.GetFirsByRoleIdAndMainRoleId(roleId: "886213CE-1DA2-47E5-BA35-9AFBBE8D7A6B", mainRoleId: "0EE68CC0-5D2D-48D7-A96E-9FC2FC446C31", default))!;
        relation.ShouldBeNull();
    }

    [Fact]
    public async Task CreateMainRoleAndRoleRLCommandResponseShouldNotBeNull()
    {
        var command = new CreateMainRoleAndRlCommand(RoleId: "886213CE-1DA2-47E5-BA35-9AFBBE8D7A6B",
            MainRoleId: "0EE68CC0-5D2D-48D7-A96E-9FC2FC446C31"

            ); ;
        var handler = new CreateMainRoleAndRlCommandHandler(_service.Object);
        CreateMainRoleAndRlCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
