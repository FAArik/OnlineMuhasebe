using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.UserAndCompanyRlFeatures.Commands.RemoveByIdUserAndCompanyRl;

public sealed class RemoveByIdUserAndCompanyRlCommandValidator : AbstractValidator<RemoveByIdUserAndCompanyRlCommand>
{
    public RemoveByIdUserAndCompanyRlCommandValidator()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id değeri boş olamaz!");
        RuleFor(x=>x.Id).NotNull().WithMessage("Id değeri boş olamaz!");
    }
}
