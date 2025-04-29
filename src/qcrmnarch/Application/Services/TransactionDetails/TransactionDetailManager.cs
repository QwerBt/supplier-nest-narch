using Application.Features.TransactionDetails.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TransactionDetails;

public class TransactionDetailManager : ITransactionDetailService
{
    private readonly ITransactionDetailRepository _transactionDetailRepository;
    private readonly TransactionDetailBusinessRules _transactionDetailBusinessRules;

    public TransactionDetailManager(ITransactionDetailRepository transactionDetailRepository, TransactionDetailBusinessRules transactionDetailBusinessRules)
    {
        _transactionDetailRepository = transactionDetailRepository;
        _transactionDetailBusinessRules = transactionDetailBusinessRules;
    }

    public async Task<TransactionDetail?> GetAsync(
        Expression<Func<TransactionDetail, bool>> predicate,
        Func<IQueryable<TransactionDetail>, IIncludableQueryable<TransactionDetail, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TransactionDetail? transactionDetail = await _transactionDetailRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return transactionDetail;
    }

    public async Task<IPaginate<TransactionDetail>?> GetListAsync(
        Expression<Func<TransactionDetail, bool>>? predicate = null,
        Func<IQueryable<TransactionDetail>, IOrderedQueryable<TransactionDetail>>? orderBy = null,
        Func<IQueryable<TransactionDetail>, IIncludableQueryable<TransactionDetail, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TransactionDetail> transactionDetailList = await _transactionDetailRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return transactionDetailList;
    }

    public async Task<TransactionDetail> AddAsync(TransactionDetail transactionDetail)
    {
        TransactionDetail addedTransactionDetail = await _transactionDetailRepository.AddAsync(transactionDetail);

        return addedTransactionDetail;
    }

    public async Task<TransactionDetail> UpdateAsync(TransactionDetail transactionDetail)
    {
        TransactionDetail updatedTransactionDetail = await _transactionDetailRepository.UpdateAsync(transactionDetail);

        return updatedTransactionDetail;
    }

    public async Task<TransactionDetail> DeleteAsync(TransactionDetail transactionDetail, bool permanent = false)
    {
        TransactionDetail deletedTransactionDetail = await _transactionDetailRepository.DeleteAsync(transactionDetail);

        return deletedTransactionDetail;
    }
}
