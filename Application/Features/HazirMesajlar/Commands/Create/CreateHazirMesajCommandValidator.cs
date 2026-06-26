using FluentValidation;

namespace Application.Features.HazirMesajlar.Commands.Create;

public class CreateHazirMesajCommandValidator : AbstractValidator<CreateHazirMesajCommand>
{
    public CreateHazirMesajCommandValidator()
    {
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
