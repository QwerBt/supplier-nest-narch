using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cities.Commands.Update;

public class UpdatedCityResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public int RegionId { get; set; }
    public Region Region { get; set; }
}