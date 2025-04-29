using FluentValidation;

namespace Application.Features.JobLevels.Commands.Delete;

public class DeleteJobLevelCommandValidator : AbstractValidator<DeleteJobLevelCommand>
{
    public DeleteJobLevelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}