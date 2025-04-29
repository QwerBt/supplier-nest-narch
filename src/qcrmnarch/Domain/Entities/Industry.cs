using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Industry:Entity<int>
{
    public Industry()
    {
        SubIndustries = new HashSet<Industry>();
        Companies = new HashSet<Company>();
    }
    public Industry(string name, Industry parentIndustry, ICollection<Industry> subIndustries, ICollection<Company> companies)
    {
        Name = name;
        ParentIndustry = parentIndustry;
        SubIndustries = subIndustries;
        Companies = companies;
    }
    public string Name { get; set; }
    public int? ParentIndustryId { get; set; }
    public virtual Industry ParentIndustry { get; set; }
    public virtual ICollection<Industry> SubIndustries { get; set; }
    public virtual ICollection<Company> Companies { get; set; }
}

