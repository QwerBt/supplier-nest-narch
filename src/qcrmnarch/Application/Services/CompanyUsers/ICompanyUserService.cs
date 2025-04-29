using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyUsers;

public interface ICompanyUserService
{
    Task<CompanyUser?> GetAsync(
        Expression<Func<CompanyUser, bool>> predicate,
        Func<IQueryable<CompanyUser>, IIncludableQueryable<CompanyUser, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CompanyUser>?> GetListAsync(
        Expression<Func<CompanyUser, bool>>? predicate = null,
        Func<IQueryable<CompanyUser>, IOrderedQueryable<CompanyUser>>? orderBy = null,
        Func<IQueryable<CompanyUser>, IIncludableQueryable<CompanyUser, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CompanyUser> AddAsync(CompanyUser companyUser);
    Task<CompanyUser> UpdateAsync(CompanyUser companyUser);
    Task<CompanyUser> DeleteAsync(CompanyUser companyUser, bool permanent = false);
}
