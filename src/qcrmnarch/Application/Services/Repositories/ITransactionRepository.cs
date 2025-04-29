using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITransactionRepository : IAsyncRepository<Transaction, int>, IRepository<Transaction, int>
{
}