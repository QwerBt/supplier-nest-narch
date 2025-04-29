using NArchitecture.Core.Application.Responses;

namespace Application.Features.Services.Queries.GetById;

public class GetByIdServiceResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}