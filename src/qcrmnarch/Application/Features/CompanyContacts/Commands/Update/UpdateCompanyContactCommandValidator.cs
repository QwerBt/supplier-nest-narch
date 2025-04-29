using FluentValidation;

namespace Application.Features.CompanyContacts.Commands.Update;

public class UpdateCompanyContactCommandValidator : AbstractValidator<UpdateCompanyContactCommand>
{
    public UpdateCompanyContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FullName).NotEmpty();
        RuleFor(c => c.Phone1).NotEmpty();
        RuleFor(c => c.Phone2).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.IsPrimary).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
    }
}