using FluentValidation;

namespace Application.Features.ItemSpecifications.Commands.Delete;

public class DeleteItemSpecificationCommandValidator : AbstractValidator<DeleteItemSpecificationCommand>
{
    public DeleteItemSpecificationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}