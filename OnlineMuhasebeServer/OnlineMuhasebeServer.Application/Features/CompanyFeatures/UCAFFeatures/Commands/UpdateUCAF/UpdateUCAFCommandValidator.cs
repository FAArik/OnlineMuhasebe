using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.UpdateUCAF;

public sealed class UpdateUCAFCommandValidator : AbstractValidator<UpdateUCAFCommand>
{
    public UpdateUCAFCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Hesap planı id boş olamaz!");
        RuleFor(x => x.Id).NotNull().WithMessage("Hesap planı id boş olamaz!");
        RuleFor(x => x.Code).NotEmpty().WithMessage("Hesap planı kodu boş olamaz!");
        RuleFor(x => x.Code).NotNull().WithMessage("Hesap planı kodu boş olamaz!");
        RuleFor(x => x.Code).MinimumLength(5).WithMessage("Hesap planı kodu en az 5 karakter olmalıdır");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Hesap planı adı boş olamaz!");
        RuleFor(x => x.Name).NotNull().WithMessage("Hesap planı adı boş olamaz!");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(x => x.CompanyId).NotNull().WithMessage("Şirket bilgisi kodu boş olamaz!");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Hesap planı tipi boş olamaz!");
        RuleFor(x => x.Type).NotNull().WithMessage("Hesap planı tipi kodu boş olamaz!");
        RuleFor(x => x.Type).MaximumLength(1).WithMessage("Hesap planı tipi 1 karakter olmalıdır!");
    }
}
