using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Towns.Commands.Create;

public class CreatedTownResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}