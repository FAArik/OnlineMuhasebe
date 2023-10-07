using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.CreateUserAndCompanyRl;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.RemoveByIdUserAndCompanyRl;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.UserAndCompanyRlFeatures;

public sealed class RemoveByIdUserAndCompanyRlCommandUnitTest
{
    private readonly Mock<IUserAndCompanyRelationshipService> _service;

    public RemoveByIdUserAndCompanyRlCommandUnitTest()
    {
        _service = new(); ;
    }
    
    [Fact]
    public async Task RemoveByIdUserAndCompanyRlCommandShouldNotBeNull()
    {
        RemoveByIdUserAndCompanyRlCommand command = new(
            Id: "918e8f70-458b-4888-98ea-fcbc879acabd");
        RemoveByIdUserAndCompanyRlCommandHandler handler = new(_service.Object);
        RemoveByIdUserAndCompanyRlCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();

    }
}
