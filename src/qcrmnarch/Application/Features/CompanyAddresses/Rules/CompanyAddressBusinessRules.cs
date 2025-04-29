using Application.Features.CompanyAddresses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CompanyAddresses.Rules;

public class CompanyAddressBusinessRules : BaseBusinessRules
{
    private readonly ICompanyAddressRepository _companyAddressRepository;
    private readonly ILocalizationService _localizationService;

    public CompanyAddressBusinessRules(ICompanyAddressRepository companyAddressRepository, ILocalizationService localizationService)
    {
        _companyAddressRepository = companyAddressRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CompanyAddressesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CompanyAddressShouldExistWhenSelected(CompanyAddress? companyAddress)
    {
        if (companyAddress == null)
            await throwBusinessException(CompanyAddressesBusinessMessages.CompanyAddressNotExists);
    }

    public async Task CompanyAddressIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CompanyAddress? companyAddress = await _companyAddressRepository.GetAsync(
            predicate: ca => ca.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyAddressShouldExistWhenSelected(companyAddress);
    }
}