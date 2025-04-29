using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CompanyImages;

public interface ICompanyImageService
{
    Task<CompanyImage?> GetAsync(
        Expression<Func<CompanyImage, bool>> predicate,
        Func<IQueryable<CompanyImage>, IIncludableQueryable<CompanyImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CompanyImage>?> GetListAsync(
        Expression<Func<CompanyImage, bool>>? predicate = null,
        Func<IQueryable<CompanyImage>, IOrderedQueryable<CompanyImage>>? orderBy = null,
        Func<IQueryable<CompanyImage>, IIncludableQueryable<CompanyImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CompanyImage> AddAsync(CompanyImage companyImage);
    Task<CompanyImage> UpdateAsync(CompanyImage companyImage);
    Task<CompanyImage> DeleteAsync(CompanyImage companyImage, bool permanent = false);
}
