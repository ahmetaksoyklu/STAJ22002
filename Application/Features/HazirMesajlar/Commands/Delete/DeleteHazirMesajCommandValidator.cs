using FluentValidation;

namespace Application.Features.HazirMesajlar.Commands.Delete;

public class DeleteHazirMesajCommandValidator : AbstractValidator<DeleteHazirMesajCommand>
{
    public DeleteHazirMesajCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);
    }
}
