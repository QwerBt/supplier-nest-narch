using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDisciplineRepository : IAsyncRepository<Discipline, int>, IRepository<Discipline, int>
{
}