using FluentValidation;

namespace Application.Features.Specifications.Commands.Delete;

public class DeleteSpecificationCommandValidator : AbstractValidator<DeleteSpecificationCommand>
{
    public DeleteSpecificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}