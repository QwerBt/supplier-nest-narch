using FluentValidation;

namespace Application.Features.Countries.Commands.Update;

public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Iso2).NotEmpty();
        RuleFor(c => c.Iso3).NotEmpty();
        RuleFor(c => c.Phonecode).NotEmpty();
        RuleFor(c => c.Capital).NotEmpty();
        RuleFor(c => c.Currency).NotEmpty();
    }
}