using FluentValidation;

namespace Application.Features.HazirMesajlar.Queries.GetList;

public class GetListHazirMesajQueryValidator : AbstractValidator<GetListHazirMesajQuery>
{
    public GetListHazirMesajQueryValidator()
    {
        // Pagination kaldirildigi icin bu sorguda format kurali bulunmuyor.
    }
}
