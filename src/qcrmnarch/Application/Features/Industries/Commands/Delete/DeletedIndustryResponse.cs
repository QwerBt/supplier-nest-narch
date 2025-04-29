using NArchitecture.Core.Application.Responses;

namespace Application.Features.Industries.Commands.Delete;

public class DeletedIndustryResponse : IResponse
{
    public int Id { get; set; }
}