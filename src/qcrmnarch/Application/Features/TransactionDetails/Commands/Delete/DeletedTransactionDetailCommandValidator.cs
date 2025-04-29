using FluentValidation;

namespace Application.Features.TransactionDetails.Commands.Delete;

public class DeleteTransactionDetailCommandValidator : AbstractValidator<DeleteTransactionDetailCommand>
{
    public DeleteTransactionDetailCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}