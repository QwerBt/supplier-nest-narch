using Application.Features.Industries.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Industries.Rules;

public class IndustryBusinessRules : BaseBusinessRules
{
    private readonly IIndustryRepository _industryRepository;
    private readonly ILocalizationService _localizationService;

    public IndustryBusinessRules(IIndustryRepository industryRepository, ILocalizationService localizationService)
    {
        _industryRepository = industryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, IndustriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task IndustryShouldExistWhenSelected(Industry? industry)
    {
        if (industry == null)
            await throwBusinessException(IndustriesBusinessMessages.IndustryNotExists);
    }

    public async Task IndustryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Industry? industry = await _industryRepository.GetAsync(
            predicate: i => i.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await IndustryShouldExistWhenSelected(industry);
    }
}