using NArchitecture.Core.Application.Responses;

namespace Application.Features.ItemSpecifications.Commands.Update;

public class UpdatedItemSpecificationResponse : IResponse
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int SpecificationId { get; set; }
}