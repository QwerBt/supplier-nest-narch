using NArchitecture.Core.Application.Responses;

namespace Application.Features.ItemSpecifications.Queries.GetById;

public class GetByIdItemSpecificationResponse : IResponse
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int SpecificationId { get; set; }
}