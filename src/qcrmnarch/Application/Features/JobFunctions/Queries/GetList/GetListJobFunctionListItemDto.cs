using NArchitecture.Core.Application.Dtos;

namespace Application.Features.JobFunctions.Queries.GetList;

public class GetListJobFunctionListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}