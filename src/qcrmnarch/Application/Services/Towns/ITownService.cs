using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Towns;

public interface ITownService
{
    Task<Town?> GetAsync(
        Expression<Func<Town, bool>> predicate,
        Func<IQueryable<Town>, IIncludableQueryable<Town, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Town>?> GetListAsync(
        Expression<Func<Town, bool>>? predicate = null,
        Func<IQueryable<Town>, IOrderedQueryable<Town>>? orderBy = null,
        Func<IQueryable<Town>, IIncludableQueryable<Town, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Town> AddAsync(Town town);
    Task<Town> UpdateAsync(Town town);
    Task<Town> DeleteAsync(Town town, bool permanent = false);
}
