using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SpecificationValues.Queries.GetList;

public class GetListSpecificationValueListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SpecificationId { get; set; }
}