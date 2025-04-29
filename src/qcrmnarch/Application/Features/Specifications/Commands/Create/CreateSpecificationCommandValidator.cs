using FluentValidation;

namespace Application.Features.Specifications.Commands.Create;

public class CreateSpecificationCommandValidator : AbstractValidator<CreateSpecificationCommand>
{
    public CreateSpecificationCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}