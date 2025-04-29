using NArchitecture.Core.Application.Responses;

namespace Application.Features.Towns.Commands.Delete;

public class DeletedTownResponse : IResponse
{
    public int Id { get; set; }
}