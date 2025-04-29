using Application.Features.ItemSpecifications.Queries.GetList;
using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Items.Queries.GetList;

public class GetListItemListItemDto : IDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }

    public List<GetListItemSpecificationListItemDto> ItemSpecifications { get; set; }
}