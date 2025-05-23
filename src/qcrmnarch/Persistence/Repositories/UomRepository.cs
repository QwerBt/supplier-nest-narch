using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UomRepository : EfRepositoryBase<Uom, int, BaseDbContext>, IUomRepository
{
    public UomRepository(BaseDbContext context) : base(context)
    {
    }
}