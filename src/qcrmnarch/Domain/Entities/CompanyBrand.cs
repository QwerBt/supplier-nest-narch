using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CompanyBrand:Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
}
