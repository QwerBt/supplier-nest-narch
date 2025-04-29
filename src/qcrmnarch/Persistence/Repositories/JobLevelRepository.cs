using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class JobLevelRepository : EfRepositoryBase<JobLevel, int, BaseDbContext>, IJobLevelRepository
{
    public JobLevelRepository(BaseDbContext context) : base(context)
    {
    }
}