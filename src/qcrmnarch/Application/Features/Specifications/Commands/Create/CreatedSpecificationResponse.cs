using NArchitecture.Core.Application.Responses;

namespace Application.Features.Specifications.Commands.Create;

public class CreatedSpecificationResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}