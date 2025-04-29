using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Industries;

public interface IIndustryService
{
    Task<Industry?> GetAsync(
        Expression<Func<Industry, bool>> predicate,
        Func<IQueryable<Industry>, IIncludableQueryable<Industry, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Industry>?> GetListAsync(
        Expression<Func<Industry, bool>>? predicate = null,
        Func<IQueryable<Industry>, IOrderedQueryable<Industry>>? orderBy = null,
        Func<IQueryable<Industry>, IIncludableQueryable<Industry, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Industry> AddAsync(Industry industry);
    Task<Industry> UpdateAsync(Industry industry);
    Task<Industry> DeleteAsync(Industry industry, bool permanent = false);
}
