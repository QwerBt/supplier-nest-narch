using Application.Features.JobLevels.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.JobLevels;

public class JobLevelManager : IJobLevelService
{
    private readonly IJobLevelRepository _jobLevelRepository;
    private readonly JobLevelBusinessRules _jobLevelBusinessRules;

    public JobLevelManager(IJobLevelRepository jobLevelRepository, JobLevelBusinessRules jobLevelBusinessRules)
    {
        _jobLevelRepository = jobLevelRepository;
        _jobLevelBusinessRules = jobLevelBusinessRules;
    }

    public async Task<JobLevel?> GetAsync(
        Expression<Func<JobLevel, bool>> predicate,
        Func<IQueryable<JobLevel>, IIncludableQueryable<JobLevel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        JobLevel? jobLevel = await _jobLevelRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return jobLevel;
    }

    public async Task<IPaginate<JobLevel>?> GetListAsync(
        Expression<Func<JobLevel, bool>>? predicate = null,
        Func<IQueryable<JobLevel>, IOrderedQueryable<JobLevel>>? orderBy = null,
        Func<IQueryable<JobLevel>, IIncludableQueryable<JobLevel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<JobLevel> jobLevelList = await _jobLevelRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return jobLevelList;
    }

    public async Task<JobLevel> AddAsync(JobLevel jobLevel)
    {
        JobLevel addedJobLevel = await _jobLevelRepository.AddAsync(jobLevel);

        return addedJobLevel;
    }

    public async Task<JobLevel> UpdateAsync(JobLevel jobLevel)
    {
        JobLevel updatedJobLevel = await _jobLevelRepository.UpdateAsync(jobLevel);

        return updatedJobLevel;
    }

    public async Task<JobLevel> DeleteAsync(JobLevel jobLevel, bool permanent = false)
    {
        JobLevel deletedJobLevel = await _jobLevelRepository.DeleteAsync(jobLevel);

        return deletedJobLevel;
    }
}
