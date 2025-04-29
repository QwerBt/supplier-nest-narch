using NArchitecture.Core.Application.Responses;

namespace Application.Features.ItemSpecifications.Commands.Delete;

public class DeletedItemSpecificationResponse : IResponse
{
    public int Id { get; set; }
}