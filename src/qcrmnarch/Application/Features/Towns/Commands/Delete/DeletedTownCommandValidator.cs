using FluentValidation;

namespace Application.Features.Towns.Commands.Delete;

public class DeleteTownCommandValidator : AbstractValidator<DeleteTownCommand>
{
    public DeleteTownCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}