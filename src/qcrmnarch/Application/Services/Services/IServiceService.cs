using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Services;

public interface IServiceService
{
    Task<Service?> GetAsync(
        Expression<Func<Service, bool>> predicate,
        Func<IQueryable<Service>, IIncludableQueryable<Service, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Service>?> GetListAsync(
        Expression<Func<Service, bool>>? predicate = null,
        Func<IQueryable<Service>, IOrderedQueryable<Service>>? orderBy = null,
        Func<IQueryable<Service>, IIncludableQueryable<Service, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Service> AddAsync(Service service);
    Task<Service> UpdateAsync(Service service);
    Task<Service> DeleteAsync(Service service, bool permanent = false);
}
