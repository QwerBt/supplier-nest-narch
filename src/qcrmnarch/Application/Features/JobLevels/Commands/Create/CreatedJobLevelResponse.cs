using NArchitecture.Core.Application.Responses;

namespace Application.Features.JobLevels.Commands.Create;

public class CreatedJobLevelResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}