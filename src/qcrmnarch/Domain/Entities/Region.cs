using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities;
public class Region:Entity<int>
{
    public Region()
    {
        HashSet<City> Cities = new HashSet<City>();
    }

    public Region(string name, int countryId, Country country, ICollection<City> cities)
    {
        Name = name;
        CountryId = countryId;
        Country = country;
        Cities = cities;
    }

    public string Name { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public virtual ICollection<City> Cities { get; set; }

}

public class Certificate : Entity<int>
{

}

public class Verify : Entity<int>
{

}

 
public class ShortList : Entity<int>
{
}

 

public class Saved : Entity<int>
{
    public SavedTypeEnum Type { get; set; }
}
