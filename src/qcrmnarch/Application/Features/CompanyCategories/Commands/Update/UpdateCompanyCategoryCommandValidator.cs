using FluentValidation;

namespace Application.Features.CompanyCategories.Commands.Update;

public class UpdateCompanyCategoryCommandValidator : AbstractValidator<UpdateCompanyCategoryCommand>
{
    public UpdateCompanyCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}