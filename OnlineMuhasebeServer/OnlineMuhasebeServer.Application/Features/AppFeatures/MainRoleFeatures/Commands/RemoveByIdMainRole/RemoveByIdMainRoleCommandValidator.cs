using FluentValidation;
using OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveByIdMainRole;

public sealed class RemoveByIdMainRoleCommandValidator:AbstractValidator<RemoveByIdMainRoleCommand>
{
    public RemoveByIdMainRoleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş zorunludur!");
        RuleFor(x => x.Id).NotNull().WithMessage("Id alanı boş zorunludur!");
    }
}
