using FluentValidation;

namespace Application.Features.SpecificationValues.Commands.Delete;

public class DeleteSpecificationValueCommandValidator : AbstractValidator<DeleteSpecificationValueCommand>
{
    public DeleteSpecificationValueCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}