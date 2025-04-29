using FluentValidation;

namespace Application.Features.ItemSpecifications.Commands.Update;

public class UpdateItemSpecificationCommandValidator : AbstractValidator<UpdateItemSpecificationCommand>
{
    public UpdateItemSpecificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ItemId).NotEmpty();
        RuleFor(c => c.Item).NotEmpty();
        RuleFor(c => c.SpecificationId).NotEmpty();
        RuleFor(c => c.Specification).NotEmpty();
    }
}