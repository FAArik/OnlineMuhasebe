using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;

public sealed class UpdateMainRoleCommandValidator:AbstractValidator<UpdateMainRoleCommand>
{
    public UpdateMainRoleCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş olamaz!");
        RuleFor(x => x.Id).NotNull().WithMessage("Id alanı boş olamaz!");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş olamaz!");
        RuleFor(x => x.Title).NotNull().WithMessage("Başlık alanı boş olamaz!");
    }
}
