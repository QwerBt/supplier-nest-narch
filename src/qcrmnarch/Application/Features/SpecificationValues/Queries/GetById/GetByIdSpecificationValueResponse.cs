using NArchitecture.Core.Application.Responses;

namespace Application.Features.SpecificationValues.Queries.GetById;

public class GetByIdSpecificationValueResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SpecificationId { get; set; }
}