using Application.Features.JobLevels.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.JobLevels.Rules;

public class JobLevelBusinessRules : BaseBusinessRules
{
    private readonly IJobLevelRepository _jobLevelRepository;
    private readonly ILocalizationService _localizationService;

    public JobLevelBusinessRules(IJobLevelRepository jobLevelRepository, ILocalizationService localizationService)
    {
        _jobLevelRepository = jobLevelRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, JobLevelsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task JobLevelShouldExistWhenSelected(JobLevel? jobLevel)
    {
        if (jobLevel == null)
            await throwBusinessException(JobLevelsBusinessMessages.JobLevelNotExists);
    }

    public async Task JobLevelIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        JobLevel? jobLevel = await _jobLevelRepository.GetAsync(
            predicate: jl => jl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await JobLevelShouldExistWhenSelected(jobLevel);
    }
}