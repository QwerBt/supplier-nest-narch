using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ItemSpecifications.Queries.GetList;

public class GetListItemSpecificationListItemDto : IDto
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int SpecificationId { get; set; }
    public string ItemName { get; set; }
    public string SpecificationName { get; set; }
    public string SpecificationValueName { get; set; }
}