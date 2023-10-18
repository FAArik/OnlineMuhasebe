using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.ReportFeatures.Commands.RequestReport;

public class RequestReportCommandValidator : AbstractValidator<RequestReportCommand>
{
    public RequestReportCommandValidator()
    {
        RuleFor(x=>x.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz") ;
        RuleFor(x=>x.Name).NotEmpty().WithMessage("Rapor adı boş olamaz") ;
        RuleFor(x=>x.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz") ;
        RuleFor(x=>x.Name).NotNull().WithMessage("Rapor adı boş olamaz") ;
    }
}
