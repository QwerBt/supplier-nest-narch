using Application.Features.Transactions.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Transactions.Rules;

public class TransactionBusinessRules : BaseBusinessRules
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ILocalizationService _localizationService;

    public TransactionBusinessRules(ITransactionRepository transactionRepository, ILocalizationService localizationService)
    {
        _transactionRepository = transactionRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TransactionsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TransactionShouldExistWhenSelected(Transaction? transaction)
    {
        if (transaction == null)
            await throwBusinessException(TransactionsBusinessMessages.TransactionNotExists);
    }

    public async Task TransactionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Transaction? transaction = await _transactionRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TransactionShouldExistWhenSelected(transaction);
    }
}