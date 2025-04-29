using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Uoms;

public interface IUomService
{
    Task<Uom?> GetAsync(
        Expression<Func<Uom, bool>> predicate,
        Func<IQueryable<Uom>, IIncludableQueryable<Uom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Uom>?> GetListAsync(
        Expression<Func<Uom, bool>>? predicate = null,
        Func<IQueryable<Uom>, IOrderedQueryable<Uom>>? orderBy = null,
        Func<IQueryable<Uom>, IIncludableQueryable<Uom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Uom> AddAsync(Uom uom);
    Task<Uom> UpdateAsync(Uom uom);
    Task<Uom> DeleteAsync(Uom uom, bool permanent = false);
}
