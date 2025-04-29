using FluentValidation;

namespace Application.Features.JobLevels.Commands.Update;

public class UpdateJobLevelCommandValidator : AbstractValidator<UpdateJobLevelCommand>
{
    public UpdateJobLevelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}