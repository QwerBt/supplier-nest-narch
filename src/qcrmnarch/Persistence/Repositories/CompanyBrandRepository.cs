using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyBrandRepository : EfRepositoryBase<CompanyBrand, int, BaseDbContext>, ICompanyBrandRepository
{
    public CompanyBrandRepository(BaseDbContext context) : base(context)
    {
    }
}