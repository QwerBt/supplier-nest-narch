using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CompanyAddresses.Queries.GetList;

public class GetListCompanyAddressListItemDto : IDto
{
    public int Id { get; set; }
    public string Street { get; set; }
    public int CityId { get; set; }
    public int TownId { get; set; }
    public int CountryId { get; set; }
    public string PostalCode { get; set; }
    public string Description { get; set; }
    public int CompanyId { get; set; }
}