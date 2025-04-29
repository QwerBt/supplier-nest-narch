using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.JobLevels;

public interface IJobLevelService
{
    Task<JobLevel?> GetAsync(
        Expression<Func<JobLevel, bool>> predicate,
        Func<IQueryable<JobLevel>, IIncludableQueryable<JobLevel, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<JobLevel>?> GetListAsync(
        Expression<Func<JobLevel, bool>>? predicate = null,
        Func<IQueryable<JobLevel>, IOrderedQueryable<JobLevel>>? orderBy = null,
        Func<IQueryable<JobLevel>, IIncludableQueryable<JobLevel, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<JobLevel> AddAsync(JobLevel jobLevel);
    Task<JobLevel> UpdateAsync(JobLevel jobLevel);
    Task<JobLevel> DeleteAsync(JobLevel jobLevel, bool permanent = false);
}
