using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SpecificationValueRepository : EfRepositoryBase<SpecificationValue, int, BaseDbContext>, ISpecificationValueRepository
{
    public SpecificationValueRepository(BaseDbContext context) : base(context)
    {
    }
}