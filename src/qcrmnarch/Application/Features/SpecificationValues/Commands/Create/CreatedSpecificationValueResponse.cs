using NArchitecture.Core.Application.Responses;

namespace Application.Features.SpecificationValues.Commands.Create;

public class CreatedSpecificationValueResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SpecificationId { get; set; }
}