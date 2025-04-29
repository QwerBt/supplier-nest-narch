using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICompanyServiceRepository : IAsyncRepository<CompanyService, int>, IRepository<CompanyService, int>
{
}