using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Disciplines.Commands.Update;

public class UpdatedDisciplineResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int JobFunctionId { get; set; }
    public JobFunction JobFunction { get; set; }
}