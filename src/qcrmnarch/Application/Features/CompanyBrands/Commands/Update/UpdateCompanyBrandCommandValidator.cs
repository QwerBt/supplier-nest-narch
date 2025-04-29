using FluentValidation;

namespace Application.Features.CompanyBrands.Commands.Update;

public class UpdateCompanyBrandCommandValidator : AbstractValidator<UpdateCompanyBrandCommand>
{
    public UpdateCompanyBrandCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
    }
}