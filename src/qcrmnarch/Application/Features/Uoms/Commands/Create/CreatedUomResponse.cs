using NArchitecture.Core.Application.Responses;

namespace Application.Features.Uoms.Commands.Create;

public class CreatedUomResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}