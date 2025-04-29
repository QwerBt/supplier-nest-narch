using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TransactionRepository : EfRepositoryBase<Transaction, int, BaseDbContext>, ITransactionRepository
{
    public TransactionRepository(BaseDbContext context) : base(context)
    {
    }
}