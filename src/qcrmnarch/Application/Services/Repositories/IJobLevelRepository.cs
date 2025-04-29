using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IJobLevelRepository : IAsyncRepository<JobLevel, int>, IRepository<JobLevel, int>
{
}