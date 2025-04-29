using Application.Features.CompanyServices.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CompanyServices.Rules;

public class CompanyServiceBusinessRules : BaseBusinessRules
{
    private readonly ICompanyServiceRepository _companyServiceRepository;
    private readonly ILocalizationService _localizationService;

    public CompanyServiceBusinessRules(ICompanyServiceRepository companyServiceRepository, ILocalizationService localizationService)
    {
        _companyServiceRepository = companyServiceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CompanyServicesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CompanyServiceShouldExistWhenSelected(CompanyService? companyService)
    {
        if (companyService == null)
            await throwBusinessException(CompanyServicesBusinessMessages.CompanyServiceNotExists);
    }

    public async Task CompanyServiceIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CompanyService? companyService = await _companyServiceRepository.GetAsync(
            predicate: cs => cs.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyServiceShouldExistWhenSelected(companyService);
    }
}