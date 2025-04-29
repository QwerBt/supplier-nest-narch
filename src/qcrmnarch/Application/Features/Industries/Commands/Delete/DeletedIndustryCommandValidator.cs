using FluentValidation;

namespace Application.Features.Industries.Commands.Delete;

public class DeleteIndustryCommandValidator : AbstractValidator<DeleteIndustryCommand>
{
    public DeleteIndustryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}