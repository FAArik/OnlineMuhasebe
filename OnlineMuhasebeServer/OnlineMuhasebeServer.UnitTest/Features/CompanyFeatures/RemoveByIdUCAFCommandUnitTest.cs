using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures;

public sealed class RemoveByIdUCAFCommandUnitTest
{
    private readonly Mock<IUCAFService> _ucafService;

    public RemoveByIdUCAFCommandUnitTest()
    {
        _ucafService = new();
    }
    [Fact]
    public async Task CheckRemoveByIdGroupAndAvailablebeBeTrue()
    {
        _ucafService.Setup(s => s.CheckRemoveByIdGroupAndAvailable(
            It.IsAny<string>(),
            It.IsAny<string>())).
            ReturnsAsync(true);
    }

    [Fact]
    public async Task RemoveByIdUCAFResponseShouldNotBeNull()
    {
        var command = new RemoveByIdUCAFCommand(
            Id: "cc6b3655-df43-479b-b0b5-73a46ff2d7d2",
            companyId: "7f3eea7a-1728-441b-a0b3-70bc72d73117"
            );

        await CheckRemoveByIdGroupAndAvailablebeBeTrue();


        var handler = new RemoveByIdUCAFCommandHandler(_ucafService.Object);

        RemoveByIdUCAFCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
