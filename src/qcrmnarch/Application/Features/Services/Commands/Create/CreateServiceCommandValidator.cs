using FluentValidation;

namespace Application.Features.Services.Commands.Create;

public class CreateServiceCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateServiceCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}