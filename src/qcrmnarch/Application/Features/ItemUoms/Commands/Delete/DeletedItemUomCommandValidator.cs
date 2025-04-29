using FluentValidation;

namespace Application.Features.ItemUoms.Commands.Delete;

public class DeleteItemUomCommandValidator : AbstractValidator<DeleteItemUomCommand>
{
    public DeleteItemUomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}