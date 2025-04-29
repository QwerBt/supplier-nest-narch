using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Industries.Queries.GetList;

public class GetListIndustryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentIndustryId { get; set; }
}