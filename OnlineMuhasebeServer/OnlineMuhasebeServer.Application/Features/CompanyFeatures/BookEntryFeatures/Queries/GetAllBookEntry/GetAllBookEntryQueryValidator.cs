using FluentValidation;

namespace OnlineMuhasebeServer.Application.Features.CompanyFeatures.BookEntryFeatures.Queries.GetAllBookEntry;

public sealed class GetAllBookEntryQueryValidator:AbstractValidator<GetAllBookEntryQuery>
{
    public GetAllBookEntryQueryValidator()
    {
        RuleFor(x => x.CompanyId).NotNull().WithMessage("Firma bilgisi boş olamaz");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Firma bilgisi boş olamaz");
    }
}
