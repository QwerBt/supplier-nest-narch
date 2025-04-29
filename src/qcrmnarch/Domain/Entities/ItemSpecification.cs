using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ItemSpecification:Entity<int>
{
    public ItemSpecification()
    {
    }

    public ItemSpecification(int ıtemId, int specificationId, int specificationValueId, Item ıtem, Specification specification, SpecificationValue specificationValue)
    {
        ItemId = ıtemId;
        SpecificationId = specificationId;
        SpecificationValueId = specificationValueId;
        Item = ıtem;
        Specification = specification;
        SpecificationValue = specificationValue;
    }

    public int ItemId { get; set; }
    public int SpecificationId { get; set; }
    public int SpecificationValueId { get; set; }

    public virtual Item? Item { get; set; }
    public virtual Specification? Specification { get; set; }
    public virtual SpecificationValue? SpecificationValue { get; set; }
}

