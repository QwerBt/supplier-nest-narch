using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DisciplineRepository : EfRepositoryBase<Discipline, int, BaseDbContext>, IDisciplineRepository
{
    public DisciplineRepository(BaseDbContext context) : base(context)
    {
    }
}