using NArchitecture.Core.Application.Responses;

namespace Application.Features.Industries.Commands.Update;

public class UpdatedIndustryResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentIndustryId { get; set; }
}