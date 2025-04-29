using FluentValidation;

namespace Application.Features.Disciplines.Commands.Update;

public class UpdateDisciplineCommandValidator : AbstractValidator<UpdateDisciplineCommand>
{
    public UpdateDisciplineCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.JobFunctionId).NotEmpty();
        RuleFor(c => c.JobFunction).NotEmpty();
    }
}