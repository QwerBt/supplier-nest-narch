using FluentValidation;

namespace Application.Features.CompanyUsers.Commands.Delete;

public class DeleteCompanyUserCommandValidator : AbstractValidator<DeleteCompanyUserCommand>
{
    public DeleteCompanyUserCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}