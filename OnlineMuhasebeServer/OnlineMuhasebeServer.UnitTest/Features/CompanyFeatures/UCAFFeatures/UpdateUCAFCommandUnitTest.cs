using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.UCAFFeatures;

public sealed class UpdateUCAFCommandUnitTest
{
    private readonly Mock<IUCAFService> _service;

    public UpdateUCAFCommandUnitTest()
    {
        _service = new();
    }
    [Fact]
    public async Task UniformChartOfAccontShouldNotBeNull()
    {
        _service.Setup(x => x.GetByIdAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(new UniformChartOfAccount());
    }
    [Fact]
    public async Task CheckNewUCAFShouldBeNull()
    {
        string companyId = "cc6b3655-df43-479b-b0b5-73a46ff2d7d2";
        string code = "100.01.001";
        UniformChartOfAccount ucaf = await _service.Object.GetByCodeAsync(code, companyId, default);
        ucaf.ShouldBeNull();
    }
    [Fact]
    public async Task UpdateUCAFCommandResponseShouldNotBeNull()
    {
        UpdateUCAFCommand command = new(
            Id: "225A393B-7B06-40C5-BCC8-28E17471F4E2",
            Code: "100.01.001",
            Name: "Merkez Kasa",
            Type: "M",
            CompanyId: "cc6b3655-df43-479b-b0b5-73a46ff2d7d2");
        await UniformChartOfAccontShouldNotBeNull();
        UpdateUCAFCommandHandler handler = new UpdateUCAFCommandHandler(_service.Object);

        UpdateUCAFCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
