using FluentValidation;

namespace Application.Features.Industries.Commands.Create;

public class CreateIndustryCommandValidator : AbstractValidator<CreateIndustryCommand>
{
    public CreateIndustryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}