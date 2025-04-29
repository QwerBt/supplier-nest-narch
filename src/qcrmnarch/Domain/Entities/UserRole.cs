using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class UserRole:Entity<int>
{
    public UserRole()
    {
    }

    public UserRole(Guid userId, User user, int roleId, Role role):this()
    {
        UserId = userId;
        User = user;
        RoleId = roleId;
        Role = role;
    }

    public Guid UserId { get; set; }
    public User User { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}