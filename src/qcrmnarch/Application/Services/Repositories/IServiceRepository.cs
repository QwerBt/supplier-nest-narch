using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IServiceRepository : IAsyncRepository<Service, int>, IRepository<Service, int>
{
}