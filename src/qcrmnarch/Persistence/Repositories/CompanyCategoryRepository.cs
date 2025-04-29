using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyCategoryRepository : EfRepositoryBase<CompanyCategory, int, BaseDbContext>, ICompanyCategoryRepository
{
    public CompanyCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}