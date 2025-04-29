using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid> {

    Task<User> GetUserByEmail(string email);
    Task AddUserAsync(User user);

}
