using NArchitecture.Core.Application.Responses;

namespace Application.Features.Uoms.Commands.Delete;

public class DeletedUomResponse : IResponse
{
    public int Id { get; set; }
}