using NArchitecture.Core.Application.Responses;

namespace Application.Features.Items.Queries.GetById;

public class GetByIdItemResponse : IResponse
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
}