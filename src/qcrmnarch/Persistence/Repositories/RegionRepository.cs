using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RegionRepository : EfRepositoryBase<Region, int, BaseDbContext>, IRegionRepository
{
    public RegionRepository(BaseDbContext context) : base(context)
    {
    }
}