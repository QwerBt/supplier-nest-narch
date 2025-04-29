using FluentValidation;

namespace Application.Features.Towns.Commands.Update;

public class UpdateTownCommandValidator : AbstractValidator<UpdateTownCommand>
{
    public UpdateTownCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
    }
}