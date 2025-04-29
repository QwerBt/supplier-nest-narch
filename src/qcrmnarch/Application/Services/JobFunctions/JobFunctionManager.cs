using Application.Features.JobFunctions.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.JobFunctions;

public class JobFunctionManager : IJobFunctionService
{
    private readonly IJobFunctionRepository _jobFunctionRepository;
    private readonly JobFunctionBusinessRules _jobFunctionBusinessRules;

    public JobFunctionManager(IJobFunctionRepository jobFunctionRepository, JobFunctionBusinessRules jobFunctionBusinessRules)
    {
        _jobFunctionRepository = jobFunctionRepository;
        _jobFunctionBusinessRules = jobFunctionBusinessRules;
    }

    public async Task<JobFunction?> GetAsync(
        Expression<Func<JobFunction, bool>> predicate,
        Func<IQueryable<JobFunction>, IIncludableQueryable<JobFunction, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        JobFunction? jobFunction = await _jobFunctionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return jobFunction;
    }

    public async Task<IPaginate<JobFunction>?> GetListAsync(
        Expression<Func<JobFunction, bool>>? predicate = null,
        Func<IQueryable<JobFunction>, IOrderedQueryable<JobFunction>>? orderBy = null,
        Func<IQueryable<JobFunction>, IIncludableQueryable<JobFunction, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<JobFunction> jobFunctionList = await _jobFunctionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return jobFunctionList;
    }

    public async Task<JobFunction> AddAsync(JobFunction jobFunction)
    {
        JobFunction addedJobFunction = await _jobFunctionRepository.AddAsync(jobFunction);

        return addedJobFunction;
    }

    public async Task<JobFunction> UpdateAsync(JobFunction jobFunction)
    {
        JobFunction updatedJobFunction = await _jobFunctionRepository.UpdateAsync(jobFunction);

        return updatedJobFunction;
    }

    public async Task<JobFunction> DeleteAsync(JobFunction jobFunction, bool permanent = false)
    {
        JobFunction deletedJobFunction = await _jobFunctionRepository.DeleteAsync(jobFunction);

        return deletedJobFunction;
    }
}
