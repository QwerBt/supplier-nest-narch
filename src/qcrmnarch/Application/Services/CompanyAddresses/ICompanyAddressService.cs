using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyAddresses;

public interface ICompanyAddressService
{
    Task<CompanyAddress?> GetAsync(
        Expression<Func<CompanyAddress, bool>> predicate,
        Func<IQueryable<CompanyAddress>, IIncludableQueryable<CompanyAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CompanyAddress>?> GetListAsync(
        Expression<Func<CompanyAddress, bool>>? predicate = null,
        Func<IQueryable<CompanyAddress>, IOrderedQueryable<CompanyAddress>>? orderBy = null,
        Func<IQueryable<CompanyAddress>, IIncludableQueryable<CompanyAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CompanyAddress> AddAsync(CompanyAddress companyAddress);
    Task<CompanyAddress> UpdateAsync(CompanyAddress companyAddress);
    Task<CompanyAddress> DeleteAsync(CompanyAddress companyAddress, bool permanent = false);
}
