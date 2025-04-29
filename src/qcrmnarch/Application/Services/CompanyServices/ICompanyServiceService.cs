using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyServices;

public interface ICompanyServiceService
{
    Task<CompanyService?> GetAsync(
        Expression<Func<CompanyService, bool>> predicate,
        Func<IQueryable<CompanyService>, IIncludableQueryable<CompanyService, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CompanyService>?> GetListAsync(
        Expression<Func<CompanyService, bool>>? predicate = null,
        Func<IQueryable<CompanyService>, IOrderedQueryable<CompanyService>>? orderBy = null,
        Func<IQueryable<CompanyService>, IIncludableQueryable<CompanyService, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CompanyService> AddAsync(CompanyService companyService);
    Task<CompanyService> UpdateAsync(CompanyService companyService);
    Task<CompanyService> DeleteAsync(CompanyService companyService, bool permanent = false);
}
