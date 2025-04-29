using NArchitecture.Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.ItemUoms.Commands.Update;

public class UpdatedItemUomResponse : IResponse
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
    public int UomId { get; set; }
    public Uom Uom { get; set; }
    public decimal ConversionRate { get; set; }
}