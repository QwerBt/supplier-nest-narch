using FluentValidation;

namespace Application.Features.Companies.Commands.Update;

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.TaxId).NotEmpty();
        RuleFor(c => c.Phone1).NotEmpty();
        RuleFor(c => c.Phone2).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Website).NotEmpty();
        RuleFor(c => c.BankAccountNumber).NotEmpty();
        RuleFor(c => c.BankName).NotEmpty();
        RuleFor(c => c.IsVerified).NotEmpty();
        RuleFor(c => c.CreditLimit).NotEmpty();
        RuleFor(c => c.PaymentTerms).NotEmpty();
        RuleFor(c => c.FacebookUrl).NotEmpty();
        RuleFor(c => c.TwitterUrl).NotEmpty();
        RuleFor(c => c.LinkedInUrl).NotEmpty();
        RuleFor(c => c.IsActive).NotEmpty();
        RuleFor(c => c.CompanyIndustryId).NotEmpty();
    }
}