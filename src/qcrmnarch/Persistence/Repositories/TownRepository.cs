using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TownRepository : EfRepositoryBase<Town, int, BaseDbContext>, ITownRepository
{
    public TownRepository(BaseDbContext context) : base(context)
    {
    }
}