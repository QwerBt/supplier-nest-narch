using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class SpecificationValue: Entity<int>
{
    public SpecificationValue()
    {
    }

    public SpecificationValue(string name, int specificationId, Specification specification)
    {
        Name = name;
        SpecificationId = specificationId;
        Specification = specification;
    }

    public string Name { get; set; }
    public int SpecificationId { get; set; }
    public virtual Specification? Specification { get; set; }
}

