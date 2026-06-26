using FluentValidation;

namespace Application.Features.HazirMesajlar.Queries.GetById;

public class GetByIdHazirMesajQueryValidator : AbstractValidator<GetByIdHazirMesajQuery>
{
    public GetByIdHazirMesajQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}
