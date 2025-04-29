using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CompanyUserRepository : EfRepositoryBase<CompanyUser, int, BaseDbContext>, ICompanyUserRepository
{
    public CompanyUserRepository(BaseDbContext context) : base(context)
    {
    }
}