using FluentValidation;

namespace Application.Features.CompanyImages.Commands.Create;

public class CreateCompanyImageCommandValidator : AbstractValidator<CreateCompanyImageCommand>
{
    public CreateCompanyImageCommandValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
        RuleFor(c => c.FilePath).NotEmpty();
        RuleFor(c => c.FileName).NotEmpty();
    }
}