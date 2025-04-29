using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Towns.Queries.GetList;

public class GetListTownListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
}