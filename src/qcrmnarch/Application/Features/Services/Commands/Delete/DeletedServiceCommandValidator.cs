using FluentValidation;

namespace Application.Features.Services.Commands.Delete;

public class DeleteServiceCommandValidator : AbstractValidator<DeleteServiceCommand>
{
    public DeleteServiceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}