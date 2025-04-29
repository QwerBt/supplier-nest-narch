using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ServiceRepository : EfRepositoryBase<Service, int, BaseDbContext>, IServiceRepository
{
    public ServiceRepository(BaseDbContext context) : base(context)
    {
    }
}