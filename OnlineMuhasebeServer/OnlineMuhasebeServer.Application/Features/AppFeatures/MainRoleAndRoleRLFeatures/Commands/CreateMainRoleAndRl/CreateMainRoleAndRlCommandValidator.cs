using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Commands.CreateMainRoleAndRl;

public sealed class CreateMainRoleAndRlCommandValidator : AbstractValidator<CreateMainRoleAndRlCommand>
{
    public CreateMainRoleAndRlCommandValidator()
    {
        RuleFor(p => p.RoleId).NotEmpty().WithMessage("Rol seçilmelidir!");
        RuleFor(p => p.RoleId).NotNull().WithMessage("Rol seçilmelidir!");
        RuleFor(p => p.MainRoleId).NotEmpty().WithMessage("Ana Rol seçilmelidir!");
        RuleFor(p => p.MainRoleId).NotNull().WithMessage("Ana Rol seçilmelidir!");

    }
}
