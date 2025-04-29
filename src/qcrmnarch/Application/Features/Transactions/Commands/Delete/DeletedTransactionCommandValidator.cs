using FluentValidation;

namespace Application.Features.Transactions.Commands.Delete;

public class DeleteTransactionCommandValidator : AbstractValidator<DeleteTransactionCommand>
{
    public DeleteTransactionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}