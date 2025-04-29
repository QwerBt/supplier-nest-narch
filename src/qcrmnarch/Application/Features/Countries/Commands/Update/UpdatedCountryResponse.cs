using NArchitecture.Core.Application.Responses;

namespace Application.Features.Countries.Commands.Update;

public class UpdatedCountryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Iso2 { get; set; }
    public string Iso3 { get; set; }
    public string Phonecode { get; set; }
    public string Capital { get; set; }
    public string Currency { get; set; }
    public string? Native { get; set; }
    public string? Emoji { get; set; }
}