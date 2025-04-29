using Application.Features.JobFunctions.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.JobFunctions.Rules;

public class JobFunctionBusinessRules : BaseBusinessRules
{
    private readonly IJobFunctionRepository _jobFunctionRepository;
    private readonly ILocalizationService _localizationService;

    public JobFunctionBusinessRules(IJobFunctionRepository jobFunctionRepository, ILocalizationService localizationService)
    {
        _jobFunctionRepository = jobFunctionRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, JobFunctionsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task JobFunctionShouldExistWhenSelected(JobFunction? jobFunction)
    {
        if (jobFunction == null)
            await throwBusinessException(JobFunctionsBusinessMessages.JobFunctionNotExists);
    }

    public async Task JobFunctionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        JobFunction? jobFunction = await _jobFunctionRepository.GetAsync(
            predicate: jf => jf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await JobFunctionShouldExistWhenSelected(jobFunction);
    }
}