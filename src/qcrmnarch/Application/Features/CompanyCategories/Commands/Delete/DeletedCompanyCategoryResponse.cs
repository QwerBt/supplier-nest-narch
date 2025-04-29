using NArchitecture.Core.Application.Responses;

namespace Application.Features.CompanyCategories.Commands.Delete;

public class DeletedCompanyCategoryResponse : IResponse
{
    public int Id { get; set; }
}