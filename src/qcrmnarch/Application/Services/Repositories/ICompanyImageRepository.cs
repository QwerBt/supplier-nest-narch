using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICompanyImageRepository : IAsyncRepository<CompanyImage, Guid>, IRepository<CompanyImage, Guid>
{
}