using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Uoms.Queries.GetList;

public class GetListUomListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}