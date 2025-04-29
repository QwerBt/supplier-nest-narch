using FluentValidation;

namespace Application.Features.CompanyImages.Commands.Update;

public class UpdateCompanyImageCommandValidator : AbstractValidator<UpdateCompanyImageCommand>
{
    public UpdateCompanyImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
        RuleFor(c => c.FilePath).NotEmpty();
        RuleFor(c => c.FileName).NotEmpty();
    }
}