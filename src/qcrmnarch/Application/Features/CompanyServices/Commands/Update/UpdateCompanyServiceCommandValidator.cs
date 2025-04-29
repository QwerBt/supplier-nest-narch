using FluentValidation;

namespace Application.Features.CompanyServices.Commands.Update;

public class UpdateCompanyServiceCommandValidator : AbstractValidator<UpdateCompanyServiceCommand>
{
    public UpdateCompanyServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
        RuleFor(c => c.ServicesId).NotEmpty();
        RuleFor(c => c.Service).NotEmpty();
    }
}