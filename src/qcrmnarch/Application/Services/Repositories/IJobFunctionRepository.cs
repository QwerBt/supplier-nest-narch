using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IJobFunctionRepository : IAsyncRepository<JobFunction, int>, IRepository<JobFunction, int>
{
}