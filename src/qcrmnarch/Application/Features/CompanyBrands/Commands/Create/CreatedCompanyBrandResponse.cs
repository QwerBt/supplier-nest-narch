using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyBrands.Commands.Create;

public class CreatedCompanyBrandResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CompanyId { get; set; }
}