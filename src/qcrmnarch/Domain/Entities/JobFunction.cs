using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class JobFunction : Entity<int>
{
    public JobFunction()
    {
        HashSet<Discipline> Disciplines = new HashSet<Discipline>();
    }

    public JobFunction(string name, string code, string description, ICollection<Discipline> disciplines):this()
    {
        Name = name;
        Code = code;
        Description = description;
        Disciplines = disciplines;
    }

    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }

    public ICollection<Discipline> Disciplines { get; set; }

}

