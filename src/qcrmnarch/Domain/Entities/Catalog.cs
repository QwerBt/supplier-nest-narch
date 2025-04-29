using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Catalog:Entity<int>
{
    public virtual Company Company { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
}
 