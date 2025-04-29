using FluentValidation;

namespace Application.Features.Disciplines.Commands.Delete;

public class DeleteDisciplineCommandValidator : AbstractValidator<DeleteDisciplineCommand>
{
    public DeleteDisciplineCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}