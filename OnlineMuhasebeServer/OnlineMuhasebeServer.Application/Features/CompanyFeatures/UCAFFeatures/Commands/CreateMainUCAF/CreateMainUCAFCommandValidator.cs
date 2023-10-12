using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateMainUCAF;

public sealed class CreateMainUCAFCommandValidator : AbstractValidator<CreateMainUCAFCommand>
{
    public CreateMainUCAFCommandValidator()
    {
        RuleFor(x => x.companyId).NotNull().WithMessage("Lütfen şirket seçiniz!");
        RuleFor(x => x.companyId).NotEmpty().WithMessage("Lütfen şirket seçiniz");
    }
}
