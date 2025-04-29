using Application.Features.Disciplines.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Disciplines.Rules;

public class DisciplineBusinessRules : BaseBusinessRules
{
    private readonly IDisciplineRepository _disciplineRepository;
    private readonly ILocalizationService _localizationService;

    public DisciplineBusinessRules(IDisciplineRepository disciplineRepository, ILocalizationService localizationService)
    {
        _disciplineRepository = disciplineRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DisciplinesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DisciplineShouldExistWhenSelected(Discipline? discipline)
    {
        if (discipline == null)
            await throwBusinessException(DisciplinesBusinessMessages.DisciplineNotExists);
    }

    public async Task DisciplineIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Discipline? discipline = await _disciplineRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DisciplineShouldExistWhenSelected(discipline);
    }
}