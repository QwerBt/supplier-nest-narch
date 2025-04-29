using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context)
        : base(context) { }

    public Task AddUserAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}
