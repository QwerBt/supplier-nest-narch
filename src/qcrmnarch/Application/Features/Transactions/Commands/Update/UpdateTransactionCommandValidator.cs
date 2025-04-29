using FluentValidation;

namespace Application.Features.Transactions.Commands.Update;

public class UpdateTransactionCommandValidator : AbstractValidator<UpdateTransactionCommand>
{
    public UpdateTransactionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CompanyId).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
        RuleFor(c => c.TransactionType).NotEmpty();
        RuleFor(c => c.TransactionDate).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.TotalAmount).NotEmpty();
    }
}