using NArchitecture.Core.Application.Responses;

namespace Application.Features.Disciplines.Commands.Delete;

public class DeletedDisciplineResponse : IResponse
{
    public int Id { get; set; }
}