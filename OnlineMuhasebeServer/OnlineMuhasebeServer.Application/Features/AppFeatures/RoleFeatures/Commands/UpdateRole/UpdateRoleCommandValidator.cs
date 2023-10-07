using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;

public sealed class UpdateRoleCommandValidator:AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().WithMessage("Id bilgisi boş olamaz!");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi boş olamaz!");
        RuleFor(x => x.Code).NotEmpty().WithMessage("Rol kodu boş olamaz!");
        RuleFor(x => x.Code).NotNull().WithMessage("Rol kodu boş olamaz!");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Rol adı boş olamaz!");
        RuleFor(x => x.Name).NotNull().WithMessage("Rol adı boş olamaz!");
    }
}
