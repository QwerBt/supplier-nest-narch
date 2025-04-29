using Application.Features.Towns.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Towns.Rules;

public class TownBusinessRules : BaseBusinessRules
{
    private readonly ITownRepository _townRepository;
    private readonly ILocalizationService _localizationService;

    public TownBusinessRules(ITownRepository townRepository, ILocalizationService localizationService)
    {
        _townRepository = townRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TownsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TownShouldExistWhenSelected(Town? town)
    {
        if (town == null)
            await throwBusinessException(TownsBusinessMessages.TownNotExists);
    }

    public async Task TownIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Town? town = await _townRepository.GetAsync(
            predicate: t => t.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TownShouldExistWhenSelected(town);
    }
}