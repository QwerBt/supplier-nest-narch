using FluentValidation;

namespace Application.Features.CompanyServices.Commands.Create;

public class CreateCompanyServiceCommandValidator : AbstractValidator<CreateCompanyServiceCommand>
{
    public CreateCompanyServiceCommandValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
        RuleFor(c => c.ServicesId).NotEmpty();
        RuleFor(c => c.Service).NotEmpty();
    }
}