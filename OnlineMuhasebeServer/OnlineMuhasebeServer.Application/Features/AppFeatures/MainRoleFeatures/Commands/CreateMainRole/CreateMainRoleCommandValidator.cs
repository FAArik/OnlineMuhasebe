using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

public sealed class CreateMainRoleCommandValidator:AbstractValidator<CreateMainRoleCommand>
{
    public CreateMainRoleCommandValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("Role başlığı boş olamaz!");
        RuleFor(p => p.Title).NotNull().WithMessage("Role başlığı boş olamaz!");
    }
}
