using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Regions;

public interface IRegionService
{
    Task<Region?> GetAsync(
        Expression<Func<Region, bool>> predicate,
        Func<IQueryable<Region>, IIncludableQueryable<Region, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Region>?> GetListAsync(
        Expression<Func<Region, bool>>? predicate = null,
        Func<IQueryable<Region>, IOrderedQueryable<Region>>? orderBy = null,
        Func<IQueryable<Region>, IIncludableQueryable<Region, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Region> AddAsync(Region region);
    Task<Region> UpdateAsync(Region region);
    Task<Region> DeleteAsync(Region region, bool permanent = false);
}
