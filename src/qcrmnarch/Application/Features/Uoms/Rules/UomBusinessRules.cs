using Application.Features.Uoms.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Uoms.Rules;

public class UomBusinessRules : BaseBusinessRules
{
    private readonly IUomRepository _uomRepository;
    private readonly ILocalizationService _localizationService;

    public UomBusinessRules(IUomRepository uomRepository, ILocalizationService localizationService)
    {
        _uomRepository = uomRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UomsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UomShouldExistWhenSelected(Uom? uom)
    {
        if (uom == null)
            await throwBusinessException(UomsBusinessMessages.UomNotExists);
    }

    public async Task UomIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Uom? uom = await _uomRepository.GetAsync(
            predicate: u => u.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UomShouldExistWhenSelected(uom);
    }
}