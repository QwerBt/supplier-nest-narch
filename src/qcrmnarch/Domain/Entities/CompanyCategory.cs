using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CompanyCategory : Entity<int>
{
    public CompanyCategory()
    {
    }
    public CompanyCategory(int companyId, Company company, int categoryId, Category category) : this()
    {
        CompanyId = companyId;
        Company = company;
        CategoryId = categoryId;
        Category = category;
    }
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
