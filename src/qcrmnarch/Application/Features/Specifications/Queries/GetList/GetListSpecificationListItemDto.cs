using Application.Features.SpecificationValues.Queries.GetList;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Specifications.Queries.GetList;

public class GetListSpecificationListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<GetListSpecificationValueListItemDto> SpecificationValues { get; set; }
}