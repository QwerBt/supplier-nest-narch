using FluentValidation;

namespace Application.Features.ItemUoms.Commands.Update;

public class UpdateItemUomCommandValidator : AbstractValidator<UpdateItemUomCommand>
{
    public UpdateItemUomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ItemId).NotEmpty();
        RuleFor(c => c.Item).NotEmpty();
        RuleFor(c => c.UomId).NotEmpty();
        RuleFor(c => c.Uom).NotEmpty();
        RuleFor(c => c.ConversionRate).NotEmpty();
    }
}