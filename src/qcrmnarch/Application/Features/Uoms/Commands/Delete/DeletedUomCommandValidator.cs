using FluentValidation;

namespace Application.Features.Uoms.Commands.Delete;

public class DeleteUomCommandValidator : AbstractValidator<DeleteUomCommand>
{
    public DeleteUomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}