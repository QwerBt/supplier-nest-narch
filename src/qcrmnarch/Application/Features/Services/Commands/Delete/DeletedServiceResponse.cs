using NArchitecture.Core.Application.Responses;

namespace Application.Features.Services.Commands.Delete;

public class DeletedServiceResponse : IResponse
{
    public int Id { get; set; }
}