using FluentValidation;

namespace Application.Features.Cities.Commands.Create;

public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CountryId).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.RegionId).NotEmpty();
        RuleFor(c => c.Region).NotEmpty();
    }
}