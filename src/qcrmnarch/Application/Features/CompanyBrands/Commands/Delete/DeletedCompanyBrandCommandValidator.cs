using FluentValidation;

namespace Application.Features.CompanyBrands.Commands.Delete;

public class DeleteCompanyBrandCommandValidator : AbstractValidator<DeleteCompanyBrandCommand>
{
    public DeleteCompanyBrandCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}