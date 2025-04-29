using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Regions.Queries.GetList;

public class GetListRegionListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SavedTypeEnum Type { get; set; }
}