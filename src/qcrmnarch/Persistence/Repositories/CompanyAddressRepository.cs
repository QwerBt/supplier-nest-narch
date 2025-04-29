using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyAddressRepository : EfRepositoryBase<CompanyAddress, int, BaseDbContext>, ICompanyAddressRepository
{
    public CompanyAddressRepository(BaseDbContext context) : base(context)
    {
    }
}