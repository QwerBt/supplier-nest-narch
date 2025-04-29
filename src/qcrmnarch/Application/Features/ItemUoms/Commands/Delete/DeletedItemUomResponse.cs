using NArchitecture.Core.Application.Responses;

namespace Application.Features.ItemUoms.Commands.Delete;

public class DeletedItemUomResponse : IResponse
{
    public int Id { get; set; }
}