using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Specifications;

public interface ISpecificationService
{
    Task<Specification?> GetAsync(
        Expression<Func<Specification, bool>> predicate,
        Func<IQueryable<Specification>, IIncludableQueryable<Specification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Specification>?> GetListAsync(
        Expression<Func<Specification, bool>>? predicate = null,
        Func<IQueryable<Specification>, IOrderedQueryable<Specification>>? orderBy = null,
        Func<IQueryable<Specification>, IIncludableQueryable<Specification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Specification> AddAsync(Specification specification);
    Task<Specification> UpdateAsync(Specification specification);
    Task<Specification> DeleteAsync(Specification specification, bool permanent = false);
}
