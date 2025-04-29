using FluentValidation;

namespace Application.Features.Uoms.Commands.Update;

public class UpdateUomCommandValidator : AbstractValidator<UpdateUomCommand>
{
    public UpdateUomCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}