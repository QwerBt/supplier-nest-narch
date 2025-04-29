using FluentValidation;

namespace Application.Features.SpecificationValues.Commands.Update;

public class UpdateSpecificationValueCommandValidator : AbstractValidator<UpdateSpecificationValueCommand>
{
    public UpdateSpecificationValueCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.SpecificationId).NotEmpty();
    }
}