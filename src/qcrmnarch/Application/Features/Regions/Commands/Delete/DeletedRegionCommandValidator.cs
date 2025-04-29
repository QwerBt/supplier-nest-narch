using FluentValidation;

namespace Application.Features.Regions.Commands.Delete;

public class DeleteRegionCommandValidator : AbstractValidator<DeleteRegionCommand>
{
    public DeleteRegionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}