﻿using Moq;
using OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Application.Services.CompanyService;
using OnlineMuhasebeServer.Application.Services.CompanyServices;
using OnlineMuhasebeServer.Domain.CompanyEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.CompanyFeatures.UCAFFeatures;

public sealed class CreateUCAFCommandUnitTest
{
    private readonly Mock<IUCAFService> _ucafService;
    private readonly Mock<IApiService> _apiService;
    private readonly Mock<ILogService> _logService;

    public CreateUCAFCommandUnitTest()
    {
        _ucafService = new();
        _apiService = new();
        _logService = new();
    }

    [Fact]
    public async Task UCAFShouldBeNull()
    {
        string companyId = "cc6b3655-df43-479b-b0b5-73a46ff2d7d2";
        string code = "100.01.001";
        UniformChartOfAccount ucaf = await _ucafService.Object.GetByCodeAsync(code, companyId, default);
        ucaf.ShouldBeNull();
    }

    [Fact]
    public async Task CreateUCAFResponseShouldNotBeNull()
    {
        var command = new CreateUCAFCommand(
            Code: "100.01.001",
            Name: "Tl Kasa",
            Type: "M",
            CompanyId: "7f3eea7a-1728-441b-a0b3-70bc72d73117"
            );
        var handler = new CreateUCAFCommandHandler(_ucafService.Object, _logService.Object, _apiService.Object);

        CreateUCAFCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();
    }
}
