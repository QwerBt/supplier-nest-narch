using FluentValidation;

namespace Application.Features.CompanyContacts.Commands.Delete;

public class DeleteCompanyContactCommandValidator : AbstractValidator<DeleteCompanyContactCommand>
{
    public DeleteCompanyContactCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}