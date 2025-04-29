using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IIndustryRepository : IAsyncRepository<Industry, int>, IRepository<Industry, int>
{
}