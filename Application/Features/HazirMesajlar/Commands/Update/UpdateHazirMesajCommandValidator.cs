using FluentValidation;

namespace Application.Features.HazirMesajlar.Commands.Update;

public class UpdateHazirMesajCommandValidator : AbstractValidator<UpdateHazirMesajCommand>
{
    public UpdateHazirMesajCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.Baslik)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(200);

        RuleFor(x => x.Konu)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(300);

        RuleFor(x => x.Icerik)
            .NotEmpty()
            .MinimumLength(5);
    }
}
