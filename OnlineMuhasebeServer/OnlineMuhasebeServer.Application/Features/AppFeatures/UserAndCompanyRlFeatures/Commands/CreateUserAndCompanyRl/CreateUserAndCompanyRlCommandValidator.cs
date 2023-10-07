using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.CreateUserAndCompanyRl;

public sealed class CreateUserAndCompanyRlCommandValidator : AbstractValidator<CreateUserAndCompanyRlCommand>
{
    public CreateUserAndCompanyRlCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı seçilmelidir!");
        RuleFor(x => x.UserId).NotNull().WithMessage("Kullanıcı seçilmelidir!");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Şirket seçilmelidir!");
        RuleFor(x => x.CompanyId).NotNull().WithMessage("Şirket seçilmelidir!");
    }
}
