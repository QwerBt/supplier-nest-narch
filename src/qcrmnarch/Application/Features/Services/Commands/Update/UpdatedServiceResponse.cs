using NArchitecture.Core.Application.Responses;

namespace Application.Features.Services.Commands.Update;

public class UpdatedServiceResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}