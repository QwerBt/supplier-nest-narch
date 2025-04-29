using FluentValidation;

namespace Application.Features.ItemSpecifications.Commands.Create;

public class CreateItemSpecificationCommandValidator : AbstractValidator<CreateItemSpecificationCommand>
{
    public CreateItemSpecificationCommandValidator()
    {
        RuleFor(c => c.ItemId).NotEmpty();
        RuleFor(c => c.Item).NotEmpty();
        RuleFor(c => c.SpecificationId).NotEmpty();
        RuleFor(c => c.Specification).NotEmpty();
    }
}