using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Disciplines;

public interface IDisciplineService
{
    Task<Discipline?> GetAsync(
        Expression<Func<Discipline, bool>> predicate,
        Func<IQueryable<Discipline>, IIncludableQueryable<Discipline, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Discipline>?> GetListAsync(
        Expression<Func<Discipline, bool>>? predicate = null,
        Func<IQueryable<Discipline>, IOrderedQueryable<Discipline>>? orderBy = null,
        Func<IQueryable<Discipline>, IIncludableQueryable<Discipline, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Discipline> AddAsync(Discipline discipline);
    Task<Discipline> UpdateAsync(Discipline discipline);
    Task<Discipline> DeleteAsync(Discipline discipline, bool permanent = false);
}
