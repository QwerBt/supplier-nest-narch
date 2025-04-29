using NArchitecture.Core.Application.Responses;

namespace Application.Features.Specifications.Commands.Update;

public class UpdatedSpecificationResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}