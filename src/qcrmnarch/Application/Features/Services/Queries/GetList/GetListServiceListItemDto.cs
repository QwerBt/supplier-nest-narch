using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Services.Queries.GetList;

public class GetListServiceListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}