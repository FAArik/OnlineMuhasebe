using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AutvschFeatures.Commands.Login
{
    public sealed record LoginCommandResponse(
        RefreshTokenDto Token,
        string Email,
        string UserId,
        string NameLastName,
        IList<CompanyDto> Companies,
        CompanyDto Company);

}
