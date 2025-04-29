using NArchitecture.Core.Application.Dtos;

namespace Application.Features.JobLevels.Queries.GetList;

public class GetListJobLevelListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
}