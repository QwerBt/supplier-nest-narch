using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class City : Entity<int>
{
    public City()
    {
 
    }

    public City(string name, int countryId, Country country, int regionId, Region region)
    {
        Name = name;
        CountryId = countryId;
        Country = country;
        RegionId = regionId;
        Region = region;
    }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public int RegionId { get; set; }
    public Region Region { get; set; }

    public ICollection<CompanyAddress> CompanyAddresses { get; set; } = new HashSet<CompanyAddress>();

}
