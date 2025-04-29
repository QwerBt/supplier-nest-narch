using Application.Features.Services.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Services.Rules;

public class ServiceBusinessRules : BaseBusinessRules
{
    private readonly IServiceRepository _serviceRepository;
    private readonly ILocalizationService _localizationService;

    public ServiceBusinessRules(IServiceRepository serviceRepository, ILocalizationService localizationService)
    {
        _serviceRepository = serviceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ServicesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ServiceShouldExistWhenSelected(Service? service)
    {
        if (service == null)
            await throwBusinessException(ServicesBusinessMessages.ServiceNotExists);
    }

    public async Task ServiceIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Service? service = await _serviceRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ServiceShouldExistWhenSelected(service);
    }
}