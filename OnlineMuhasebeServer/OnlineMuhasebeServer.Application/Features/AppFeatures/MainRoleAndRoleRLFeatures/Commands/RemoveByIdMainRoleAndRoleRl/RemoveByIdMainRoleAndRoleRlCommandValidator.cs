using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.RemoveByIdMainRoleAndRoleRl;

public sealed class RemoveByIdMainRoleAndRoleRlCommandValidator : AbstractValidator<RemoveByIdMainRoleAndRoleRlCommand>
{
    public RemoveByIdMainRoleAndRoleRlCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id alanı zorunludur!");
        RuleFor(p => p.Id).NotNull().WithMessage("Id alanı zorunludur!");
    }
}
