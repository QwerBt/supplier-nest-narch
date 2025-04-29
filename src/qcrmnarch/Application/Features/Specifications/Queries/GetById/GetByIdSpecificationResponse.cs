using NArchitecture.Core.Application.Responses;

namespace Application.Features.Specifications.Queries.GetById;

public class GetByIdSpecificationResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}