using FluentValidation;

namespace Application.Features.ItemUoms.Commands.Create;

public class CreateItemUomCommandValidator : AbstractValidator<CreateItemUomCommand>
{
    public CreateItemUomCommandValidator()
    {
        RuleFor(c => c.ItemId).NotEmpty();
        RuleFor(c => c.Item).NotEmpty();
        RuleFor(c => c.UomId).NotEmpty();
        RuleFor(c => c.Uom).NotEmpty();
        RuleFor(c => c.ConversionRate).NotEmpty();
    }
}