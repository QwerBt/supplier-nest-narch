using Application.Features.Regions.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Regions.Rules;

public class RegionBusinessRules : BaseBusinessRules
{
    private readonly IRegionRepository _regionRepository;
    private readonly ILocalizationService _localizationService;

    public RegionBusinessRules(IRegionRepository regionRepository, ILocalizationService localizationService)
    {
        _regionRepository = regionRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RegionsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RegionShouldExistWhenSelected(Region? region)
    {
        if (region == null)
            await throwBusinessException(RegionsBusinessMessages.RegionNotExists);
    }

    public async Task RegionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Region? region = await _regionRepository.GetAsync(
            predicate: r => r.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RegionShouldExistWhenSelected(region);
    }
}