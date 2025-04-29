using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyImageRepository : EfRepositoryBase<CompanyImage, Guid, BaseDbContext>, ICompanyImageRepository
{
    public CompanyImageRepository(BaseDbContext context) : base(context)
    {
    }
}