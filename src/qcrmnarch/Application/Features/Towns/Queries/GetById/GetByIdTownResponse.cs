using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Towns.Queries.GetById;

public class GetByIdTownResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}