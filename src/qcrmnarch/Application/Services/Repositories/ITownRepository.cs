using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITownRepository : IAsyncRepository<Town, int>, IRepository<Town, int>
{
}