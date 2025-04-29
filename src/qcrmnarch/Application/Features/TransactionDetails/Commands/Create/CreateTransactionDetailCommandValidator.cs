using FluentValidation;

namespace Application.Features.TransactionDetails.Commands.Create;

public class CreateTransactionDetailCommandValidator : AbstractValidator<CreateTransactionDetailCommand>
{
    public CreateTransactionDetailCommandValidator()
    {
        RuleFor(c => c.TransactionId).NotEmpty();
        RuleFor(c => c.Transaction).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
        RuleFor(c => c.UnitPrice).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty();
        RuleFor(c => c.Discount).NotEmpty();
        RuleFor(c => c.Tax).NotEmpty();
    }
}