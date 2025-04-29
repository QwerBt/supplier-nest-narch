using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUomRepository : IAsyncRepository<Uom, int>, IRepository<Uom, int>
{
}