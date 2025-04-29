using Application.Features.TransactionDetails.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.TransactionDetails.Rules;

public class TransactionDetailBusinessRules : BaseBusinessRules
{
    private readonly ITransactionDetailRepository _transactionDetailRepository;
    private readonly ILocalizationService _localizationService;

    public TransactionDetailBusinessRules(ITransactionDetailRepository transactionDetailRepository, ILocalizationService localizationService)
    {
        _transactionDetailRepository = transactionDetailRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TransactionDetailsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TransactionDetailShouldExistWhenSelected(TransactionDetail? transactionDetail)
    {
        if (transactionDetail == null)
            await throwBusinessException(TransactionDetailsBusinessMessages.TransactionDetailNotExists);
    }

    public async Task TransactionDetailIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        TransactionDetail? transactionDetail = await _transactionDetailRepository.GetAsync(
            predicate: td => td.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TransactionDetailShouldExistWhenSelected(transactionDetail);
    }
}