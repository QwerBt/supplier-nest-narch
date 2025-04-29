using FluentValidation;

namespace Application.Features.JobLevels.Commands.Create;

public class CreateJobLevelCommandValidator : AbstractValidator<CreateJobLevelCommand>
{
    public CreateJobLevelCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}