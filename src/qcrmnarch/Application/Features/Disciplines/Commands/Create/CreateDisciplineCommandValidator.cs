using FluentValidation;

namespace Application.Features.Disciplines.Commands.Create;

public class CreateDisciplineCommandValidator : AbstractValidator<CreateDisciplineCommand>
{
    public CreateDisciplineCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.JobFunctionId).NotEmpty();
        RuleFor(c => c.JobFunction).NotEmpty();
    }
}