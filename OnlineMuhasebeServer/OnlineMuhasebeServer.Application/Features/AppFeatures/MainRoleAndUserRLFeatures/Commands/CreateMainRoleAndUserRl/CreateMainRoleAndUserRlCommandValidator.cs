using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleAndUserRLFeatures.Commands.CreateMainRoleAndUserRl;

public sealed class CreateMainRoleAndUserRlCommandValidator : AbstractValidator<RemoveByIdMainRoleAndUserRelationshipCommand>
{
    public CreateMainRoleAndUserRlCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanici seçmelisiniz!");
        RuleFor(x => x.UserId).NotNull().WithMessage("Kullanici seçmelisiniz!");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Şirket seçmelisiniz!");
        RuleFor(x => x.CompanyId).NotNull().WithMessage("Şirket seçmelisiniz!");
        RuleFor(x => x.MainRoleId).NotEmpty().WithMessage("Ana rol seçmelisiniz!");
        RuleFor(x => x.MainRoleId).NotNull().WithMessage("Ana rol seçmelisiniz!");
    }
}
