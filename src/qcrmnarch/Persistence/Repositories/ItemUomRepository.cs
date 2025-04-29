using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ItemUomRepository : EfRepositoryBase<ItemUom, int, BaseDbContext>, IItemUomRepository
{
    public ItemUomRepository(BaseDbContext context) : base(context)
    {
    }
}