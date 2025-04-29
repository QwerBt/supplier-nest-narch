using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyCategories.Commands.Update;

public class UpdatedCompanyCategoryResponse : IResponse
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int CategoryId { get; set; }
}