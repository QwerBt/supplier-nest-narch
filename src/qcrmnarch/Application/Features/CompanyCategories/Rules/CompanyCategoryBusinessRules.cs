using Application.Features.CompanyCategories.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CompanyCategories.Rules;

public class CompanyCategoryBusinessRules : BaseBusinessRules
{
    private readonly ICompanyCategoryRepository _companyCategoryRepository;
    private readonly ILocalizationService _localizationService;

    public CompanyCategoryBusinessRules(ICompanyCategoryRepository companyCategoryRepository, ILocalizationService localizationService)
    {
        _companyCategoryRepository = companyCategoryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CompanyCategoriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CompanyCategoryShouldExistWhenSelected(CompanyCategory? companyCategory)
    {
        if (companyCategory == null)
            await throwBusinessException(CompanyCategoriesBusinessMessages.CompanyCategoryNotExists);
    }

    public async Task CompanyCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CompanyCategory? companyCategory = await _companyCategoryRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyCategoryShouldExistWhenSelected(companyCategory);
    }
}