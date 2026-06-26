using FluentValidation;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0);

        RuleFor(x => x.CategoryId)
            .GreaterThan(0);

        RuleFor(x => x.ProductName)
            .NotEmpty()
            .MaximumLength(40);

        RuleFor(x => x.UnitPrice)
            .GreaterThanOrEqualTo(0);
    }
}
