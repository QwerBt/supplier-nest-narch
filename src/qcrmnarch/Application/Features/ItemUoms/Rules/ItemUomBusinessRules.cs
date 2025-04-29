using Application.Features.ItemUoms.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ItemUoms.Rules;

public class ItemUomBusinessRules : BaseBusinessRules
{
    private readonly IItemUomRepository _itemUomRepository;
    private readonly ILocalizationService _localizationService;

    public ItemUomBusinessRules(IItemUomRepository itemUomRepository, ILocalizationService localizationService)
    {
        _itemUomRepository = itemUomRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ItemUomsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ItemUomShouldExistWhenSelected(ItemUom? itemUom)
    {
        if (itemUom == null)
            await throwBusinessException(ItemUomsBusinessMessages.ItemUomNotExists);
    }

    public async Task ItemUomIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ItemUom? itemUom = await _itemUomRepository.GetAsync(
            predicate: iu => iu.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ItemUomShouldExistWhenSelected(itemUom);
    }
}