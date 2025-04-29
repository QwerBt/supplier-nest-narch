using Application.Features.CompanyContacts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CompanyContacts.Rules;

public class CompanyContactBusinessRules : BaseBusinessRules
{
    private readonly ICompanyContactRepository _companyContactRepository;
    private readonly ILocalizationService _localizationService;

    public CompanyContactBusinessRules(ICompanyContactRepository companyContactRepository, ILocalizationService localizationService)
    {
        _companyContactRepository = companyContactRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CompanyContactsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CompanyContactShouldExistWhenSelected(CompanyContact? companyContact)
    {
        if (companyContact == null)
            await throwBusinessException(CompanyContactsBusinessMessages.CompanyContactNotExists);
    }

    public async Task CompanyContactIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CompanyContact? companyContact = await _companyContactRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyContactShouldExistWhenSelected(companyContact);
    }
}