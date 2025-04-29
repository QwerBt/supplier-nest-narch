using FluentValidation;

namespace Application.Features.Regions.Commands.Create;

public class CreateRegionCommandValidator : AbstractValidator<CreateRegionCommand>
{
    public CreateRegionCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
    }
}