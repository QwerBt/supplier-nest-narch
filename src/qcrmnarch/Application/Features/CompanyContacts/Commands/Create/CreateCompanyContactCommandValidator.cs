using FluentValidation;

namespace Application.Features.CompanyContacts.Commands.Create;

public class CreateCompanyContactCommandValidator : AbstractValidator<CreateCompanyContactCommand>
{
    public CreateCompanyContactCommandValidator()
    {
        RuleFor(c => c.FullName).NotEmpty();
        RuleFor(c => c.Phone1).NotEmpty();
        RuleFor(c => c.Phone2).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Position).NotEmpty();
        RuleFor(c => c.IsPrimary).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
    }
}