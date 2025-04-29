using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyBrands;

public interface ICompanyBrandService
{
    Task<CompanyBrand?> GetAsync(
        Expression<Func<CompanyBrand, bool>> predicate,
        Func<IQueryable<CompanyBrand>, IIncludableQueryable<CompanyBrand, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CompanyBrand>?> GetListAsync(
        Expression<Func<CompanyBrand, bool>>? predicate = null,
        Func<IQueryable<CompanyBrand>, IOrderedQueryable<CompanyBrand>>? orderBy = null,
        Func<IQueryable<CompanyBrand>, IIncludableQueryable<CompanyBrand, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CompanyBrand> AddAsync(CompanyBrand companyBrand);
    Task<CompanyBrand> UpdateAsync(CompanyBrand companyBrand);
    Task<CompanyBrand> DeleteAsync(CompanyBrand companyBrand, bool permanent = false);
}
