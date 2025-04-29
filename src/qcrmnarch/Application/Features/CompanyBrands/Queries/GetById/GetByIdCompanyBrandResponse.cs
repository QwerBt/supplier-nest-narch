using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyBrands.Queries.GetById;

public class GetByIdCompanyBrandResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CompanyId { get; set; }
}