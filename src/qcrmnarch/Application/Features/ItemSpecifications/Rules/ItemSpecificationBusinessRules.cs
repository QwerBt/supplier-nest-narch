using Application.Features.ItemSpecifications.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ItemSpecifications.Rules;

public class ItemSpecificationBusinessRules : BaseBusinessRules
{
    private readonly IItemSpecificationRepository _itemSpecificationRepository;
    private readonly ILocalizationService _localizationService;

    public ItemSpecificationBusinessRules(IItemSpecificationRepository itemSpecificationRepository, ILocalizationService localizationService)
    {
        _itemSpecificationRepository = itemSpecificationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ItemSpecificationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ItemSpecificationShouldExistWhenSelected(ItemSpecification? itemSpecification)
    {
        if (itemSpecification == null)
            await throwBusinessException(ItemSpecificationsBusinessMessages.ItemSpecificationNotExists);
    }

    public async Task ItemSpecificationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ItemSpecification? itemSpecification = await _itemSpecificationRepository.GetAsync(
            predicate: isp => isp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ItemSpecificationShouldExistWhenSelected(itemSpecification);
    }
}