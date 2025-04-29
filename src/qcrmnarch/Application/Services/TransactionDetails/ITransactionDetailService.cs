using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TransactionDetails;

public interface ITransactionDetailService
{
    Task<TransactionDetail?> GetAsync(
        Expression<Func<TransactionDetail, bool>> predicate,
        Func<IQueryable<TransactionDetail>, IIncludableQueryable<TransactionDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TransactionDetail>?> GetListAsync(
        Expression<Func<TransactionDetail, bool>>? predicate = null,
        Func<IQueryable<TransactionDetail>, IOrderedQueryable<TransactionDetail>>? orderBy = null,
        Func<IQueryable<TransactionDetail>, IIncludableQueryable<TransactionDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TransactionDetail> AddAsync(TransactionDetail transactionDetail);
    Task<TransactionDetail> UpdateAsync(TransactionDetail transactionDetail);
    Task<TransactionDetail> DeleteAsync(TransactionDetail transactionDetail, bool permanent = false);
}
