using FluentValidation;

namespace Application.Features.CompanyCategories.Commands.Create;

public class CreateCompanyCategoryCommandValidator : AbstractValidator<CreateCompanyCategoryCommand>
{
    public CreateCompanyCategoryCommandValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}