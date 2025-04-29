using NArchitecture.Core.Application.Responses;

namespace Application.Features.Services.Commands.Create;

public class CreatedServiceResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}