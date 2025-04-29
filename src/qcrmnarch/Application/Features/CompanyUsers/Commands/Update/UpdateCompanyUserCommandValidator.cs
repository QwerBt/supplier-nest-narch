using FluentValidation;

namespace Application.Features.CompanyUsers.Commands.Update;

public class UpdateCompanyUserCommandValidator : AbstractValidator<UpdateCompanyUserCommand>
{
    public UpdateCompanyUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.User).NotEmpty();
    }
}