using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyServiceRepository : EfRepositoryBase<CompanyService, int, BaseDbContext>, ICompanyServiceRepository
{
    public CompanyServiceRepository(BaseDbContext context) : base(context)
    {
    }
}