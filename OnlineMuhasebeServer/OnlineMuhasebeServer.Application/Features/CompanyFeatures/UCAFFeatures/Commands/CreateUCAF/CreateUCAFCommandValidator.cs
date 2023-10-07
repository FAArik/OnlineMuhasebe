using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

public sealed class CreateUCAFCommandValidator:AbstractValidator<CreateUCAFCommand>
{
    public CreateUCAFCommandValidator()
    {
        RuleFor(x=>x.Code).NotEmpty().WithMessage("Hesap planı kodu boş olamaz!");
        RuleFor(x=>x.Code).NotNull().WithMessage("Hesap planı kodu boş olamaz!");
        //RuleFor(x => x.Code).MinimumLength(4).WithMessage("Hesap planı kodu en az 4 karakter olmalıdır");
        RuleFor(x=>x.Name).NotEmpty().WithMessage("Hesap planı adı boş olamaz!");
        RuleFor(x=>x.Name).NotNull().WithMessage("Hesap planı adı boş olamaz!");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(x => x.CompanyId).NotNull().WithMessage("Şirket bilgisi kodu boş olamaz!");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Hesap planı tipi boş olamaz!");
        RuleFor(x => x.Type).NotNull().WithMessage("Hesap planı tipi kodu boş olamaz!");
        RuleFor(x => x.Type).MaximumLength(1).WithMessage("Hesap planı tipi 1 karakter olmalıdır!");
    }
}
