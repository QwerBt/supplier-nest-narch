using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Transactions;

public interface ITransactionService
{
    Task<Transaction?> GetAsync(
        Expression<Func<Transaction, bool>> predicate,
        Func<IQueryable<Transaction>, IIncludableQueryable<Transaction, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Transaction>?> GetListAsync(
        Expression<Func<Transaction, bool>>? predicate = null,
        Func<IQueryable<Transaction>, IOrderedQueryable<Transaction>>? orderBy = null,
        Func<IQueryable<Transaction>, IIncludableQueryable<Transaction, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Transaction> AddAsync(Transaction transaction);
    Task<Transaction> UpdateAsync(Transaction transaction);
    Task<Transaction> DeleteAsync(Transaction transaction, bool permanent = false);
}
