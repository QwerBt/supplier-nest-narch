using Application.Features.Specifications.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Specifications.Rules;

public class SpecificationBusinessRules : BaseBusinessRules
{
    private readonly ISpecificationRepository _specificationRepository;
    private readonly ILocalizationService _localizationService;

    public SpecificationBusinessRules(ISpecificationRepository specificationRepository, ILocalizationService localizationService)
    {
        _specificationRepository = specificationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SpecificationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SpecificationShouldExistWhenSelected(Specification? specification)
    {
        if (specification == null)
            await throwBusinessException(SpecificationsBusinessMessages.SpecificationNotExists);
    }

    public async Task SpecificationIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Specification? specification = await _specificationRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SpecificationShouldExistWhenSelected(specification);
    }
}