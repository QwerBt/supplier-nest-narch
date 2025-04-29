using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class JobFunctionRepository : EfRepositoryBase<JobFunction, int, BaseDbContext>, IJobFunctionRepository
{
    public JobFunctionRepository(BaseDbContext context) : base(context)
    {
    }

}