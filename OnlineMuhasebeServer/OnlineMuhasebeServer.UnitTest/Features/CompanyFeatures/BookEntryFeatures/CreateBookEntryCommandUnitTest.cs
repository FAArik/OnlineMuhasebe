using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Commands.CreateBookEntry;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.BookEntryFeatures;

public sealed class CreateBookEntryCommandUnitTest
{
    private readonly Mock<IBookEntryService> _service;
    private readonly Mock<ILogService> _logservice;
    private readonly Mock<IApiService> _apiservice;

    public CreateBookEntryCommandUnitTest()
    {
        _service = new();
        _logservice = new();
        _apiservice = new();
    }
    [Fact]
    public async Task CreateBookEntryCommandResponseShouldNotBeNull()
    {
        CreateBookEntryCommand command = new(
            CompanyId: "99f4be28-44ec-4a39-8e2e-16bddd61b799",
            Type: "Muavin",
            Description: "Yevmiye Fişi",
            Date: "12.02.2023"
            );
        CreateBookEntryCommandHandler handler = new(_service.Object, _logservice.Object, _apiservice.Object);
        CreateBookEntryCommandResponse response = await handler.Handle(command, default);

        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();

    }



}
