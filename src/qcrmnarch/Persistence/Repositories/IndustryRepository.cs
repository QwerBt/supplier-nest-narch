using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class IndustryRepository : EfRepositoryBase<Industry, int, BaseDbContext>, IIndustryRepository
{
    public IndustryRepository(BaseDbContext context) : base(context)
    {
    }
}