using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TransactionDetailRepository : EfRepositoryBase<TransactionDetail, int, BaseDbContext>, ITransactionDetailRepository
{
    public TransactionDetailRepository(BaseDbContext context) : base(context)
    {
    }
}