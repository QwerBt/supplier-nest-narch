using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Service : Entity<int>
{
    public string Name { get; set; }

}
