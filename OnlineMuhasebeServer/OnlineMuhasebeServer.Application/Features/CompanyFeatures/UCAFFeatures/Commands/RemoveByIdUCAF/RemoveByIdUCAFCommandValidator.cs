using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.RemoveByIdUCAF;

public class RemoveByIdUCAFCommandValidator : AbstractValidator<RemoveByIdUCAFCommand>
{
    public RemoveByIdUCAFCommandValidator()
    {
        RuleFor(x => x.companyId).NotEmpty().WithMessage("Şirket alanı boş olamaz!");
        RuleFor(x => x.companyId).NotNull().WithMessage("Şirket alanı boş olamaz!");
        RuleFor(x => x.Id).NotNull().WithMessage("Id alanı boş olamaz!");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş olamaz!");
    }
}
