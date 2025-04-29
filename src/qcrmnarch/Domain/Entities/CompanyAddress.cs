using NArchitecture.Core.Persistence.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class CompanyAddress : Entity<int>
{

    public string Street { get; set; }           // Sokak Adı
    public int CityId { get; set; }             // Şehir
    public City? City { get; set; }             // Şehir
    public int TownId { get; set; }            // Eyalet/İlçe
    public Town? Town { get; set; }            // Eyalet/İlçe
    public int CountryId { get; set; }          // Ülke
    public Country? Country { get; set; }          // Ülke

    public string PostalCode { get; set; }      // Posta Kodu
    public string Description { get; set; }
    public int CompanyId { get; set; }           // İlişkili Firma ID
    public virtual Company? Company { get; set; }         // İlişkili Firma (Navigation Property)



    public CompanyAddress()
    {
    }

    public CompanyAddress(string street, int cityId, City city, int townId, Town town, int countryId, Country country, string postalCode, string description, int companyId, Company? company)
    {
        Street = street;
        CityId = cityId;
        City = city;
        TownId = townId;
        Town = town;
        CountryId = countryId;
        Country = country;
        PostalCode = postalCode;
        Description = description;
        CompanyId = companyId;
        Company = company;
    }
}
