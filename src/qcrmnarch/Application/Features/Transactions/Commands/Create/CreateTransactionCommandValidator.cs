using FluentValidation;

namespace Application.Features.Transactions.Commands.Create;

public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
        RuleFor(c => c.TransactionType).NotEmpty();
        RuleFor(c => c.TransactionDate).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.TotalAmount).NotEmpty();
    }
}