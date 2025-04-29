using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class JobLevel: Entity<int>
{
    public JobLevel()
    {
    }

    public JobLevel(string name, string? code, string? description):this()
    {
        Name = name;
        Code = code;
        Description = description;
    }

    public string Name { get; set; }

    public string? Code { get; set; }
    public string? Description { get; set; }


}

