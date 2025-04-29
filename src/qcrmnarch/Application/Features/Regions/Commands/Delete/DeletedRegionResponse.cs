using NArchitecture.Core.Application.Responses;

namespace Application.Features.Regions.Commands.Delete;

public class DeletedRegionResponse : IResponse
{
    public int Id { get; set; }
}