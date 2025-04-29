using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICompanyCategoryRepository : IAsyncRepository<CompanyCategory, int>, IRepository<CompanyCategory, int>
{

}