using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyCategories.Commands.Create;

public class CreatedCompanyCategoryResponse : IResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int CategoryId { get; set; }
}