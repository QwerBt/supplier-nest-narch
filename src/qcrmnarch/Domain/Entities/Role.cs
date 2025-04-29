using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Role : Entity<int>
{
    public Role()
    {
    }

    public Role(string name, string? description, ICollection<UserRole> userRoles):this()
    {
        Name = name;
        Description = description;
        UserRoles = userRoles;
    }

    public string Name { get; set; }
    public string? Description { get; set; }
    // Rolün ait olduğu kullanıcılar
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
