using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Disciplines.Queries.GetList;

public class GetListDisciplineListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int JobFunctionId { get; set; }
    public JobFunction JobFunction { get; set; }
}