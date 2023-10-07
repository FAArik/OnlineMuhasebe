using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleCommandValidator: AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x=>x.Code).NotEmpty().WithMessage("Rol kodu boş olamaz!");
        RuleFor(x=>x.Code).NotNull().WithMessage("Rol kodu boş olamaz!");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Rol adı boş olamaz!");
        RuleFor(x => x.Name).NotNull().WithMessage("Rol adı boş olamaz!");
    }
}
