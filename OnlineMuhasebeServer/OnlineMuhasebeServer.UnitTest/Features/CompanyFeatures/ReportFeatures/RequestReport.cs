using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.ReportFeatures;

public sealed class RequestReport
{
    private readonly Mock<IReportService> _service;

    public RequestReport()
    {
        _service = new();
    }
    [Fact]
    public async Task RequuestReportCommandShouldNotBeNull()
    {
        RequestReportCommand command = new(
            Name: "Hesap Planı",
            CompanyId: "");
        RequestReportCommandHandler handler = new RequestReportCommandHandler(_service.Object);

        RequestReportCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
