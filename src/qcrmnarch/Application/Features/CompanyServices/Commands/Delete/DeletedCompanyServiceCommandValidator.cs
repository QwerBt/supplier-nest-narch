using FluentValidation;

namespace Application.Features.CompanyServices.Commands.Delete;

public class DeleteCompanyServiceCommandValidator : AbstractValidator<DeleteCompanyServiceCommand>
{
    public DeleteCompanyServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}