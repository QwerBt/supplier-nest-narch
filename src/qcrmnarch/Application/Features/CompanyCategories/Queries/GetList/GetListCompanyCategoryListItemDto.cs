using Application.Features.Categories.Queries.GetList;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CompanyCategories.Queries.GetList;

public class GetListCompanyCategoryListItemDto : IDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int CategoryId { get; set; }

    public string CompanyName { get; set; }
    public string CategoryName { get; set; }

    public int ProductsCount { get; set; }
    public int ItemsCount { get; set; }
    public List<GetListCategoryListItemDto> Categories { get; set; }


}