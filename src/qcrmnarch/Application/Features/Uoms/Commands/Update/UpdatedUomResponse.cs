using NArchitecture.Core.Application.Responses;

namespace Application.Features.Uoms.Commands.Update;

public class UpdatedUomResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}