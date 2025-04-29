using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyCategories.Queries.GetById;

public class GetByIdCompanyCategoryResponse : IResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int CategoryId { get; set; }
}