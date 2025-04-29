using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IItemSpecificationRepository : IAsyncRepository<ItemSpecification, int>, IRepository<ItemSpecification, int>
{
}