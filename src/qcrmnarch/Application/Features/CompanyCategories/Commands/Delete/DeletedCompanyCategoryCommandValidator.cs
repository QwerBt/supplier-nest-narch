using FluentValidation;

namespace Application.Features.CompanyCategories.Commands.Delete;

public class DeleteCompanyCategoryCommandValidator : AbstractValidator<DeleteCompanyCategoryCommand>
{
    public DeleteCompanyCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}