using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IItemUomRepository : IAsyncRepository<ItemUom, int>, IRepository<ItemUom, int>
{
}