using NArchitecture.Core.Application.Responses;

namespace Application.Features.Specifications.Commands.Delete;

public class DeletedSpecificationResponse : IResponse
{
    public int Id { get; set; }
}