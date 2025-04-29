using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyCategories;

public interface ICompanyCategoryService
{
    Task<CompanyCategory?> GetAsync(
        Expression<Func<CompanyCategory, bool>> predicate,
        Func<IQueryable<CompanyCategory>, IIncludableQueryable<CompanyCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CompanyCategory>?> GetListAsync(
        Expression<Func<CompanyCategory, bool>>? predicate = null,
        Func<IQueryable<CompanyCategory>, IOrderedQueryable<CompanyCategory>>? orderBy = null,
        Func<IQueryable<CompanyCategory>, IIncludableQueryable<CompanyCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CompanyCategory> AddAsync(CompanyCategory companyCategory);
    Task<CompanyCategory> UpdateAsync(CompanyCategory companyCategory);
    Task<CompanyCategory> DeleteAsync(CompanyCategory companyCategory, bool permanent = false);
}
