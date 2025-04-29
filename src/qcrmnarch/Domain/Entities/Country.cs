using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Country : Entity<int>
{
    public Country()
    {
    }

    public Country(string name, string ıso2, string ıso3, string phonecode, string capital, string currency, string native, string emoji, ICollection<City> cities, ICollection<Region> regions):this()
    {
        Name = name;
        Iso2 = ıso2;
        Iso3 = ıso3;
        Phonecode = phonecode;
        Capital = capital;
        Currency = currency;
        Native = native;
        Emoji = emoji;
        Cities = cities;
        Regions = regions;
    }

    public string Name {get;set;}
     public string Iso2 {get;set;}
     public string Iso3 {get;set;}
     public string Phonecode {get;set;}
     public string Capital {get;set;}
     public string Currency {get;set;}
     public string? Native {get;set;}
     public string? Emoji { get; set; }

    public ICollection<City>? Cities{ get; set; } = new HashSet<City>();
    public ICollection<Region>? Regions { get; set; } = new HashSet<Region>();
    public ICollection<CompanyAddress>? CompanyAddresses{ get; set; } = new HashSet<CompanyAddress>();


}
