using FluentValidation;

namespace Application.Features.Cities.Commands.Update;

public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CountryId).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.RegionId).NotEmpty();
        RuleFor(c => c.Region).NotEmpty();
    }
}