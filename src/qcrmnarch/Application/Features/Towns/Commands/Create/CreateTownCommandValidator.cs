using FluentValidation;

namespace Application.Features.Towns.Commands.Create;

public class CreateTownCommandValidator : AbstractValidator<CreateTownCommand>
{
    public CreateTownCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
    }
}