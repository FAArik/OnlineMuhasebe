using OnlineMuhasebeServer.Application.Abstractions;
using OnlineMuhasebeServer.Application.Features.AppFeatures.AutvschFeatures.Commands.Login;
using OnlineMuhasebeServer.Application.Messaging;
using OnlineMuhasebeServer.Application.Services.AppServices;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Domain.Dtos;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IJwtProvider jwtProvider, IAuthService authService)
        {
            _jwtProvider = jwtProvider;
            _authService = authService;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            AppUser user = await _authService.GetByEmailOrUserNameAsync(request.EmailOrUserName);
            if (user == null) throw new Exception("Kullanıcı bulunamadı!");

            var checkUser = await _authService.CheckPasswordAsync(user, request.Password);
            if (!checkUser) throw new Exception("Şifreniz Yanlış!");

            IList<UserAndCompanyRelationship> companies = await _authService.GetCompanyListByUserIdAsync(user.Id);
            if (companies.Count == 0) throw new Exception("Herhangi bir şirkette kayıtlı değilsiniz!");
            IList<CompanyDto> companyDtos = companies.Select(s => new Domain.Dtos.CompanyDto(CompanyId: s.Company.Id, CompanyName: s.Company.Name)).ToList();
            LoginCommandResponse response = new(
                Token: await _jwtProvider.CreateTokenAsync(user),
                Email: user.Email,
                UserId: user.Id,
                NameLastName: user.NameLastName,
                Companies: companyDtos,
                Company: companyDtos[0],
                Year:DateTime.Now.Year
                );
            return response;
        }
    }
}
