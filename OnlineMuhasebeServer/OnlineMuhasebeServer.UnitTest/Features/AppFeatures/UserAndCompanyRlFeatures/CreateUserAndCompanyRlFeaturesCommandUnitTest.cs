using Moq;
using OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.CreateUserAndCompanyRl;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using Shouldly;
using System.ComponentModel.Design;

namespace OnlineMuhasebeServer.UnitTest.Features.AppFeatures.UserAndCompanyRlFeatures;

public sealed class CreateUserAndCompanyRlFeaturesCommandUnitTest
{
    private readonly Mock<IUserAndCompanyRelationshipService> _service;

    public CreateUserAndCompanyRlFeaturesCommandUnitTest()
    {
        _service = new(); ;
    }
    [Fact]
    public async Task UserAndCompanyRelationshipShouldBeNull()
    {
        UserAndCompanyRelationship userAndCompanyRelationship = await _service.Object.GetByUserIdAndCompanyId(
            UserId: "918e8f70-458b-4888-98ea-fcbc879acabd",
            CompanyId: "abec3ad2-d1df-461a-885b-735f3bb35dc4",
            cancellationToken: default);
        userAndCompanyRelationship.ShouldBeNull();
    }
    [Fact]
    public async Task UserAndCompanyRlCommandResponseShouldNotBeNull()
    {
        CreateUserAndCompanyRlCommand command = new(
            UserId: "918e8f70-458b-4888-98ea-fcbc879acabd",
            CompanyId: "abec3ad2-d1df-461a-885b-735f3bb35dc4");
        CreateUserAndCompanyRlCommandHandler handler = new(_service.Object);
        CreateUserAndCompanyRlCommandResponse response = await handler.Handle(command, default);
        response.ShouldNotBeNull();
        response.Message.ShouldNotBeEmpty();

    }
}
