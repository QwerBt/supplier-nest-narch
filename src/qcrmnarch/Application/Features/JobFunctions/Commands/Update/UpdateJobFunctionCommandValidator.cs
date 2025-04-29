using FluentValidation;

namespace Application.Features.JobFunctions.Commands.Update;

public class UpdateJobFunctionCommandValidator : AbstractValidator<UpdateJobFunctionCommand>
{
    public UpdateJobFunctionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}