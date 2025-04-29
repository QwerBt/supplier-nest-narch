using NArchitecture.Core.Application.Responses;

namespace Application.Features.SpecificationValues.Commands.Delete;

public class DeletedSpecificationValueResponse : IResponse
{
    public int Id { get; set; }
}