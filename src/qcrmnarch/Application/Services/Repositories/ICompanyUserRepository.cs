using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICompanyUserRepository : IAsyncRepository<CompanyUser, int>, IRepository<CompanyUser, int>
{
}