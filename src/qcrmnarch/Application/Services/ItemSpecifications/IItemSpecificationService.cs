using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ItemSpecifications;

public interface IItemSpecificationService
{
    Task<ItemSpecification?> GetAsync(
        Expression<Func<ItemSpecification, bool>> predicate,
        Func<IQueryable<ItemSpecification>, IIncludableQueryable<ItemSpecification, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ItemSpecification>?> GetListAsync(
        Expression<Func<ItemSpecification, bool>>? predicate = null,
        Func<IQueryable<ItemSpecification>, IOrderedQueryable<ItemSpecification>>? orderBy = null,
        Func<IQueryable<ItemSpecification>, IIncludableQueryable<ItemSpecification, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ItemSpecification> AddAsync(ItemSpecification itemSpecification);
    Task<ItemSpecification> UpdateAsync(ItemSpecification itemSpecification);
    Task<ItemSpecification> DeleteAsync(ItemSpecification itemSpecification, bool permanent = false);
}
