using Microsoft.AspNetCore.Identity;
using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Application.Features.AppFeatures.AutvschFeatures.Commands.Login;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Commands.GetTokenByRefreshToken;

public sealed class GetTokenByRefreshTokenCommandHandler : ICommandHandler<GetTokenByRefreshTokenCommand, GetTokenByRefreshTokenCommandResponse>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly UserManager<AppUser> _userManager;
    private readonly IAuthService _authService;

    public GetTokenByRefreshTokenCommandHandler(IJwtProvider jwtProvider, IAuthService authService, UserManager<AppUser> userManager)
    {
        _jwtProvider = jwtProvider;
        _authService = authService;
        _userManager = userManager;
    }
    public async Task<GetTokenByRefreshTokenCommandResponse> Handle(GetTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) throw new Exception("Kullanıcı bulunamadı!");

        
        if (user.RefreshToken!= request.RefreshToken) throw new Exception("RefreshToken geçerli değil!");

        IList<UserAndCompanyRelationship> companies = await _authService.GetCompanyListByUserIdAsync(user.Id);
        if (companies.Count == 0) throw new Exception("Herhangi bir şirkette kayıtlı değilsiniz!");

        IList<CompanyDto> companyDtos = companies.Select(s => new Domain.Dtos.CompanyDto(CompanyId: s.Company.Id, CompanyName: s.Company.Name)).ToList();
        GetTokenByRefreshTokenCommandResponse response = new(
            Token: await _jwtProvider.CreateTokenAsync(user),
            Email: user.Email,
            UserId: user.Id,
            NameLastName: user.NameLastName,
            Companies: companyDtos,
            Company: companyDtos.Where(x=>x.CompanyId==request.CompanyId).FirstOrDefault(),
            Year: DateTime.Now.Year
            );
        return response;
    }
}
