using Application.Features.SpecificationValues.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.SpecificationValues.Rules;

public class SpecificationValueBusinessRules : BaseBusinessRules
{
    private readonly ISpecificationValueRepository _specificationValueRepository;
    private readonly ILocalizationService _localizationService;

    public SpecificationValueBusinessRules(ISpecificationValueRepository specificationValueRepository, ILocalizationService localizationService)
    {
        _specificationValueRepository = specificationValueRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SpecificationValuesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SpecificationValueShouldExistWhenSelected(SpecificationValue? specificationValue)
    {
        if (specificationValue == null)
            await throwBusinessException(SpecificationValuesBusinessMessages.SpecificationValueNotExists);
    }

    public async Task SpecificationValueIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        SpecificationValue? specificationValue = await _specificationValueRepository.GetAsync(
            predicate: sv => sv.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SpecificationValueShouldExistWhenSelected(specificationValue);
    }
}