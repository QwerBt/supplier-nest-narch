using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyContacts;

public interface ICompanyContactService
{
    Task<CompanyContact?> GetAsync(
        Expression<Func<CompanyContact, bool>> predicate,
        Func<IQueryable<CompanyContact>, IIncludableQueryable<CompanyContact, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CompanyContact>?> GetListAsync(
        Expression<Func<CompanyContact, bool>>? predicate = null,
        Func<IQueryable<CompanyContact>, IOrderedQueryable<CompanyContact>>? orderBy = null,
        Func<IQueryable<CompanyContact>, IIncludableQueryable<CompanyContact, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CompanyContact> AddAsync(CompanyContact companyContact);
    Task<CompanyContact> UpdateAsync(CompanyContact companyContact);
    Task<CompanyContact> DeleteAsync(CompanyContact companyContact, bool permanent = false);
}
