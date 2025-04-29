using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SpecificationRepository : EfRepositoryBase<Specification, int, BaseDbContext>, ISpecificationRepository
{
    public SpecificationRepository(BaseDbContext context) : base(context)
    {
    }
}