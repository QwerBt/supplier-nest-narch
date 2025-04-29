using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SpecificationValues;

public interface ISpecificationValueService
{
    Task<SpecificationValue?> GetAsync(
        Expression<Func<SpecificationValue, bool>> predicate,
        Func<IQueryable<SpecificationValue>, IIncludableQueryable<SpecificationValue, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<SpecificationValue>?> GetListAsync(
        Expression<Func<SpecificationValue, bool>>? predicate = null,
        Func<IQueryable<SpecificationValue>, IOrderedQueryable<SpecificationValue>>? orderBy = null,
        Func<IQueryable<SpecificationValue>, IIncludableQueryable<SpecificationValue, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<SpecificationValue> AddAsync(SpecificationValue specificationValue);
    Task<SpecificationValue> UpdateAsync(SpecificationValue specificationValue);
    Task<SpecificationValue> DeleteAsync(SpecificationValue specificationValue, bool permanent = false);
}
