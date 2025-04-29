using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Towns.Commands.Update;

public class UpdatedTownResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}