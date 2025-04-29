using Application.Features.CompanyImages.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CompanyImages.Rules;

public class CompanyImageBusinessRules : BaseBusinessRules
{
    private readonly ICompanyImageRepository _companyImageRepository;
    private readonly ILocalizationService _localizationService;

    public CompanyImageBusinessRules(ICompanyImageRepository companyImageRepository, ILocalizationService localizationService)
    {
        _companyImageRepository = companyImageRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CompanyImagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CompanyImageShouldExistWhenSelected(CompanyImage? companyImage)
    {
        if (companyImage == null)
            await throwBusinessException(CompanyImagesBusinessMessages.CompanyImageNotExists);
    }

    public async Task CompanyImageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CompanyImage? companyImage = await _companyImageRepository.GetAsync(
            predicate: ci => ci.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CompanyImageShouldExistWhenSelected(companyImage);
    }
}