using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ItemUoms;

public interface IItemUomService
{
    Task<ItemUom?> GetAsync(
        Expression<Func<ItemUom, bool>> predicate,
        Func<IQueryable<ItemUom>, IIncludableQueryable<ItemUom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ItemUom>?> GetListAsync(
        Expression<Func<ItemUom, bool>>? predicate = null,
        Func<IQueryable<ItemUom>, IOrderedQueryable<ItemUom>>? orderBy = null,
        Func<IQueryable<ItemUom>, IIncludableQueryable<ItemUom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ItemUom> AddAsync(ItemUom itemUom);
    Task<ItemUom> UpdateAsync(ItemUom itemUom);
    Task<ItemUom> DeleteAsync(ItemUom itemUom, bool permanent = false);
}
