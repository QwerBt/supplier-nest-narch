using NArchitecture.Core.Application.Responses;

namespace Application.Features.Uoms.Queries.GetById;

public class GetByIdUomResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}