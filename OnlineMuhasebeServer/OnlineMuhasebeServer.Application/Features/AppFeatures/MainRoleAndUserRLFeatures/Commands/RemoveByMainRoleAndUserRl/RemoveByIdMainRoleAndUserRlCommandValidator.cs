using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.RemoveByMainRoleAndUserRl;

public sealed class RemoveByIdMainRoleAndUserRlCommandValidator : AbstractValidator<RemoveByIdMainRoleAndUserRlCommand>
{
    public RemoveByIdMainRoleAndUserRlCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().WithMessage("Id alanı boş olamaz!");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş olamaz!");
    }
}
