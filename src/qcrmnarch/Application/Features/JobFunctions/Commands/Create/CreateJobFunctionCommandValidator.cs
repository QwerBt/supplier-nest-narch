using FluentValidation;

namespace Application.Features.JobFunctions.Commands.Create;

public class CreateJobFunctionCommandValidator : AbstractValidator<CreateJobFunctionCommand>
{
    public CreateJobFunctionCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}