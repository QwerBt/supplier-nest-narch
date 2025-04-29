using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.JobFunctions;

public interface IJobFunctionService
{
    Task<JobFunction?> GetAsync(
        Expression<Func<JobFunction, bool>> predicate,
        Func<IQueryable<JobFunction>, IIncludableQueryable<JobFunction, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<JobFunction>?> GetListAsync(
        Expression<Func<JobFunction, bool>>? predicate = null,
        Func<IQueryable<JobFunction>, IOrderedQueryable<JobFunction>>? orderBy = null,
        Func<IQueryable<JobFunction>, IIncludableQueryable<JobFunction, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<JobFunction> AddAsync(JobFunction jobFunction);
    Task<JobFunction> UpdateAsync(JobFunction jobFunction);
    Task<JobFunction> DeleteAsync(JobFunction jobFunction, bool permanent = false);
}
