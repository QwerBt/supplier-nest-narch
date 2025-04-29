using Application.Features.Transactions.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Transactions;

public class TransactionManager : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly TransactionBusinessRules _transactionBusinessRules;

    public TransactionManager(ITransactionRepository transactionRepository, TransactionBusinessRules transactionBusinessRules)
    {
        _transactionRepository = transactionRepository;
        _transactionBusinessRules = transactionBusinessRules;
    }

    public async Task<Transaction?> GetAsync(
        Expression<Func<Transaction, bool>> predicate,
        Func<IQueryable<Transaction>, IIncludableQueryable<Transaction, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Transaction? transaction = await _transactionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return transaction;
    }

    public async Task<IPaginate<Transaction>?> GetListAsync(
        Expression<Func<Transaction, bool>>? predicate = null,
        Func<IQueryable<Transaction>, IOrderedQueryable<Transaction>>? orderBy = null,
        Func<IQueryable<Transaction>, IIncludableQueryable<Transaction, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Transaction> transactionList = await _transactionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return transactionList;
    }

    public async Task<Transaction> AddAsync(Transaction transaction)
    {
        Transaction addedTransaction = await _transactionRepository.AddAsync(transaction);

        return addedTransaction;
    }

    public async Task<Transaction> UpdateAsync(Transaction transaction)
    {
        Transaction updatedTransaction = await _transactionRepository.UpdateAsync(transaction);

        return updatedTransaction;
    }

    public async Task<Transaction> DeleteAsync(Transaction transaction, bool permanent = false)
    {
        Transaction deletedTransaction = await _transactionRepository.DeleteAsync(transaction);

        return deletedTransaction;
    }
}
