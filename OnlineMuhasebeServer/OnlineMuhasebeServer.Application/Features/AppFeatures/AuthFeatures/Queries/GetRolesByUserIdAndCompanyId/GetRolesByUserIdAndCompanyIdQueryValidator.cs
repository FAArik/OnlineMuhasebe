using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.AuthFeatures.Queries.GetRolesByUserIdAndCompanyId;

public class GetRolesByUserIdAndCompanyIdQueryValidator:AbstractValidator<GetRolesByUserIdAndCompanyIdQuery>
{
    public GetRolesByUserIdAndCompanyIdQueryValidator()
    {
        RuleFor(x=>x.userId).NotEmpty().WithMessage("Bir kullanıcı seçiniz!");
        RuleFor(x=>x.userId).NotNull().WithMessage("Bir kullanıcı seçiniz!");
        RuleFor(x=>x.companyId).NotEmpty().WithMessage("Bir firma seçiniz!");
        RuleFor(x=>x.companyId).NotNull().WithMessage("Bir firma seçiniz!");
    }
}
