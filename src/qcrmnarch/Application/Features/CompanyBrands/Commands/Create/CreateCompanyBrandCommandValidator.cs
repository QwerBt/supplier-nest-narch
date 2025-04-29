using FluentValidation;

namespace Application.Features.CompanyBrands.Commands.Create;

public class CreateCompanyBrandCommandValidator : AbstractValidator<CreateCompanyBrandCommand>
{
    public CreateCompanyBrandCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
    }
}