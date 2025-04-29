using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Discipline : Entity<int>
{
    public Discipline()
    {
    }

    public Discipline(string name,string code, string description, int jobFunctionId, JobFunction jobFunction):this()
    {
        Name = name;
        Code = code;
        Description = description;
        JobFunctionId = jobFunctionId;
        JobFunction = jobFunction;
    }

    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public int JobFunctionId { get; set; }
    public JobFunction JobFunction { get; set; }
}

