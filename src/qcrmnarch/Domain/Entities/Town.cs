using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Town:Entity<int>
{
    public Town()
    {
    }
    public Town(string name, int cityId, City city)
    {
        Name = name;
        CityId = cityId;
        City = city;
    }
    public string Name { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }

    public ICollection<CompanyAddress> CompanyAddresses { get; set; } = new HashSet<CompanyAddress>();
}

