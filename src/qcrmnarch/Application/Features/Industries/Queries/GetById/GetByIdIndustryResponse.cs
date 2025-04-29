using NArchitecture.Core.Application.Responses;

namespace Application.Features.Industries.Queries.GetById;

public class GetByIdIndustryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentIndustryId { get; set; }
}