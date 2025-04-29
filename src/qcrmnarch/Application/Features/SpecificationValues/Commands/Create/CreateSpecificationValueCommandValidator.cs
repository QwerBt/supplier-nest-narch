using FluentValidation;

namespace Application.Features.SpecificationValues.Commands.Create;

public class CreateSpecificationValueCommandValidator : AbstractValidator<CreateSpecificationValueCommand>
{
    public CreateSpecificationValueCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.SpecificationId).NotEmpty();
    }
}