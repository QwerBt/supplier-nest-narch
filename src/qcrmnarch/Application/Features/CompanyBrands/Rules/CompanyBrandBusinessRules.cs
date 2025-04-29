using Application.Features.CompanyBrands.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CompanyBrands.Rules;

public class CompanyBrandBusinessRules : BaseBusinessRules
{
    private readonly ICompanyBrandRepository _companyBrandRepository;
    private readonly ILocalizationService _localizationService;

    public CompanyBrandBusinessRules(ICompanyBrandRepository companyBrandRepository, ILocalizationService localizationService)
    {
        _companyBrandRepository = companyBrandRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CompanyBrandsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CompanyBrandShouldExistWhenSelected(CompanyBrand? companyBrand)
    {
        if (companyBrand == null)
            await throwBusinessException(CompanyBrandsBusinessMessages.CompanyBrandNotExists);
    }

    public async Task CompanyBrandIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CompanyBrand? companyBrand = await _companyBrandRepository.GetAsync(
            predicate: cb => cb.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyBrandShouldExistWhenSelected(companyBrand);
    }
}