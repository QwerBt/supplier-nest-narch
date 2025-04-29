using Application.Features.CompanyUsers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CompanyUsers.Rules;

public class CompanyUserBusinessRules : BaseBusinessRules
{
    private readonly ICompanyUserRepository _companyUserRepository;
    private readonly ILocalizationService _localizationService;

    public CompanyUserBusinessRules(ICompanyUserRepository companyUserRepository, ILocalizationService localizationService)
    {
        _companyUserRepository = companyUserRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CompanyUsersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CompanyUserShouldExistWhenSelected(CompanyUser? companyUser)
    {
        if (companyUser == null)
            await throwBusinessException(CompanyUsersBusinessMessages.CompanyUserNotExists);
    }

    public async Task CompanyUserIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CompanyUser? companyUser = await _companyUserRepository.GetAsync(
            predicate: cu => cu.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyUserShouldExistWhenSelected(companyUser);
    }
}