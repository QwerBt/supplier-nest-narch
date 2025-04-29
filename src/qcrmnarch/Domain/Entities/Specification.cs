using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Specification : Entity<int>
{
    public Specification()
    {
    }

    public Specification(string name, ICollection<SpecificationValue> specificationValues, ICollection<ItemSpecification> ıtemSpecifications)
    {
        Name = name;
        SpecificationValues = specificationValues;
        ItemSpecifications = ıtemSpecifications;
    }

    public string Name { get; set; }

    public virtual ICollection<SpecificationValue>? SpecificationValues { get; set; }=new HashSet<SpecificationValue>();
    public virtual ICollection<ItemSpecification>? ItemSpecifications { get; set; } = new HashSet<ItemSpecification>();
}

