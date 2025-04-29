using NArchitecture.Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.ItemUoms.Queries.GetList;

public class GetListItemUomListItemDto : IDto
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int UomId { get; set; }
    public Uom Uom { get; set; }
    public decimal ConversionRate { get; set; }
}