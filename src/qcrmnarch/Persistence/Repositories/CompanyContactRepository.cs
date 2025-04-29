using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyContactRepository : EfRepositoryBase<CompanyContact, int, BaseDbContext>, ICompanyContactRepository
{
    public CompanyContactRepository(BaseDbContext context) : base(context)
    {
    }
}