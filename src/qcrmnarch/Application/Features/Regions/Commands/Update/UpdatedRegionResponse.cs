using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Regions.Commands.Update;

public class UpdatedRegionResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SavedTypeEnum Type { get; set; }
}