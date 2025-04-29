using FluentValidation;

namespace Application.Features.CompanyAddresses.Commands.Delete;

public class DeleteCompanyAddressCommandValidator : AbstractValidator<DeleteCompanyAddressCommand>
{
    public DeleteCompanyAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}