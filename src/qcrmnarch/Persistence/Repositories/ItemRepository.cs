using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ItemRepository : EfRepositoryBase<Item, int, BaseDbContext>, IItemRepository
{
    public ItemRepository(BaseDbContext context) : base(context)
    {
    }
}