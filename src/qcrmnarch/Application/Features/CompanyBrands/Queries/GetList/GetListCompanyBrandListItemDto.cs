using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CompanyBrands.Queries.GetList;

public class GetListCompanyBrandListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CompanyId { get; set; }
}