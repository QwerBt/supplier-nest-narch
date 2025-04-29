using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ItemSpecificationRepository : EfRepositoryBase<ItemSpecification, int, BaseDbContext>, IItemSpecificationRepository
{
    public ItemSpecificationRepository(BaseDbContext context) : base(context)
    {
    }
}