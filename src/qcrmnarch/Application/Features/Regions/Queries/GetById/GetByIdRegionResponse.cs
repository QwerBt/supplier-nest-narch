using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Regions.Queries.GetById;

public class GetByIdRegionResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SavedTypeEnum Type { get; set; }
}