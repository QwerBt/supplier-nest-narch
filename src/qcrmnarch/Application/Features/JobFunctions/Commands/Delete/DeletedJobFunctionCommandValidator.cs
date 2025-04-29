using FluentValidation;

namespace Application.Features.JobFunctions.Commands.Delete;

public class DeleteJobFunctionCommandValidator : AbstractValidator<DeleteJobFunctionCommand>
{
    public DeleteJobFunctionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}