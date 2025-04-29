using FluentValidation;

namespace Application.Features.CompanyImages.Commands.Delete;

public class DeleteCompanyImageCommandValidator : AbstractValidator<DeleteCompanyImageCommand>
{
    public DeleteCompanyImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}